/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Concepts.Installations;
using Dolittle.DependencyInversion;
using Dolittle.Lifecycle;
using Dolittle.TimeSeries.DataPoints;
using TimeSeries.Identification;
using Single = Dolittle.TimeSeries.DataTypes.Single;

namespace TimeSeries.DataPoints
{
    /// <summary>
    /// Represents an implementation of <see cref="IDataPointMessenger"/>
    /// </summary>
    [Singleton]
    public class DataPointMessenger : IDataPointMessenger
    {
        /// <inheritdoc/>
        public event DataPointReady DataPointReady = (d) => {};

        readonly FactoryFor<ITagDataPointIdentifier> _identifierFactory;

        /// <summary>
        /// Initializes a new instance of <see cref="DataPointMessenger"/>
        /// </summary>
        /// <param name="identifierFactory"><see cref="ITagDataPointIdentifier"/> for identifying tags</param>
        public DataPointMessenger(FactoryFor<ITagDataPointIdentifier> identifierFactory)
        {
            _identifierFactory = identifierFactory;
        }

        /// <inheritdoc/>
        public void Push(SiteId siteId, InstallationId installation, NodeId node, string metricType, double value)
        {
            //var identity = _identifierFactory().GetOrUpdate(location, node, metricType);
            //DataPointReady(new TagDataPoint(identity.Tag, (Single)value));
        }
    }
}