// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Concepts.Installations;
using Dolittle.ReadModels;

namespace Read.Installations
{
    public class SiteStatus : IReadModel
    {
        static TimeSpan _threshold = TimeSpan.FromMinutes(5);

        public SiteId Id { get; set; }

        public SiteName Name { get; set; }

        public int TotalNodes { get; set; }

        public int ConnectedNodes => LastSeenNodes.Values.Count(_ => DateTimeOffset.UtcNow.Subtract(_) < _threshold);

        public TimeSpan Threshold => _threshold;

        public IDictionary<string, DateTimeOffset> LastSeenNodes { get; set; }

        public DateTimeOffset LastSeen => LastSeenNodes.Values.OrderByDescending(_ => _).FirstOrDefault();
    }
}