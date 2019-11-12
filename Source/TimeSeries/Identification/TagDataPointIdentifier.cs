/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Concepts.Locations;
using Concepts.Locations.Nodes;
using Dolittle.Collections;
using Dolittle.Lifecycle;
using Dolittle.ReadModels;
using Dolittle.TimeSeries;
using Dolittle.TimeSeries.Identity;
using TimeSeries.Connectors;

namespace TimeSeries.Identification
{
    /// <summary>
    /// Represents an implementation of <see cref="ITagDataPointIdentifier"/>
    /// </summary>
    [SingletonPerTenant]
    public class TagDataPointIdentifier : ITagDataPointIdentifier
    {
        readonly ConcurrentDictionary<string, TagToTimeSeries> _cache = new ConcurrentDictionary<string, TagToTimeSeries>();
        readonly IReadModelRepositoryFor<TagToTimeSeries> _readModels;
        readonly ITimeSeriesIdentifier _timeSeriesIdentifier;

        /// <summary>
        /// Initializes a new instance of <see cref="TagDataPointIdentifier"/>
        /// </summary>
        /// <param name="readModels"><see cref="IReadModelRepositoryFor{T}"/> for <see cref="TagToTimeSeries"/></param>
        /// <param name="timeSeriesIdentifier"><see cref="ITimeSeriesIdentifier"/> for identification up towards the runtime</param>
        public TagDataPointIdentifier(
            IReadModelRepositoryFor<TagToTimeSeries> readModels,
            ITimeSeriesIdentifier timeSeriesIdentifier)
        {
            _readModels = readModels;
            _timeSeriesIdentifier = timeSeriesIdentifier;
            Populate();
        }

        /// <inheritdoc/>
        public TagToTimeSeries GetOrUpdate(LocationId location, NodeId node, string metricType)
        {
            var tag = $"{location.Value}_{node.Value}_{metricType}";
            if (_cache.ContainsKey(tag)) return _cache[tag];

            var map = new TagToTimeSeries { Id = Guid.NewGuid(), Tag = tag };
            _readModels.Insert(map);
            _timeSeriesIdentifier.Register(TimeSeriesConnector.SourceName, tag, map.Id);

            _cache[tag] = map;

            return map;
        }

        void Populate()
        {
            var all = new Dictionary<Dolittle.TimeSeries.DataPoints.Tag, TimeSeriesId>();

            _readModels.Query.ForEach(_ =>
            {
                _cache[_.Tag] = _;
                all[_.Tag] = _.Id;
            });

            _timeSeriesIdentifier.Register(TimeSeriesConnector.SourceName, all);
        }
    }
}