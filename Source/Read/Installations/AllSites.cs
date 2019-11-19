/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.Installations
{
    /// <summary>
    /// Represents a query for getting all locactions
    /// </summary>
    public class AllSites : IQueryFor<Site>
    {
        readonly IReadModelRepositoryFor<Site> _sites;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sites"></param>
        public AllSites(IReadModelRepositoryFor<Site> sites)
        {
            _sites = sites;
        }

        public IQueryable<Site> Query => _sites.Query;
    }
}