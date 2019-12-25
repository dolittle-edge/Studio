// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.Installations
{
    public class AllInstallations : IQueryFor<Installation>
    {
        readonly IReadModelRepositoryFor<Installation> _installations;

        public AllInstallations(IReadModelRepositoryFor<Installation> installations)
        {
            _installations = installations;
        }

        public IQueryable<Installation> Query => _installations.Query;
    }
}