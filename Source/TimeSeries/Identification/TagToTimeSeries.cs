// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Dolittle.ReadModels;
using Dolittle.TimeSeries;

namespace TimeSeries.Identification
{
    /// <summary>
    /// Represents a map between a tag name and a <see cref="TimeSeriesId"/>.
    /// </summary>
    public class TagToTimeSeries : IReadModel
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the tag name.
        /// </summary>
        public string Tag { get; set; }
    }
}