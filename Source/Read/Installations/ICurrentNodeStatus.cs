/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using Concepts.Installations;

namespace Read.Installations
{
    public interface ICurrentNodeStatus
    {
        void Report(SiteId siteId, InstallationId installationId, NodeId nodeId, IDictionary<string, float> metrics, IDictionary<string,string> infos);
    }
}