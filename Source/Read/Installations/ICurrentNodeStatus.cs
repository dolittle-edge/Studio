// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using Concepts.Installations;

namespace Read.Installations
{
    public interface ICurrentNodeStatus
    {
        void Report(SiteId siteId, InstallationId installationId, NodeId nodeId, IDictionary<string, float> metrics, IDictionary<string, string> infos);
    }
}