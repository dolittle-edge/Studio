/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.ReadModels;
using Dolittle.Rules;
using Read.Locations;

namespace Rules.Locations
{
    public class NotExist : IRuleImplementationFor<Domain.Locations.NotExist>
    {
        
        //readonly IReadModelRepositoryFor<Location> _locations;
        //public NotExist(IReadModelRepositoryFor<Location> locations) => _locations = locations;
        public Domain.Locations.NotExist Rule => (id) => true; //_locations.GetById(id) == null;
    }
}