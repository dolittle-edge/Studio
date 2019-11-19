/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.Installation
{
    /// <summary>
    /// Represents a query for getting all locactions
    /// </summary>
    public class AllInstallations : IQueryFor<Installation>
    {
        readonly IReadModelRepositoryFor<Installation> _installations;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="installations"></param>
        public AllInstallations(IReadModelRepositoryFor<Installation> installations)
        {
            _installations = installations;
        }

        public IQueryable<Installation> Query => _installations.Query;
    }
}