/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.ReadModels;
using Dolittle.Rules;
using Read.Locations;
using System.Linq;

namespace Rules.Locations
{
    public class NameMustBeUnique : IRuleImplementationFor<Domain.Locations.NameMustBeUnique>
    {
        readonly IReadModelRepositoryFor<Location> _locations;
        public NameMustBeUnique(IReadModelRepositoryFor<Location> locations) => _locations = locations;
        public Domain.Locations.NameMustBeUnique Rule => (name) => !_locations.Query.Any(_ => _.Name == name);
    }
}