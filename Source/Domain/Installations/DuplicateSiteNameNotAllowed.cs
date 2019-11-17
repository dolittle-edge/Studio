/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using System.Linq;
using Dolittle.Rules;

namespace Domain.Installations
{
    public class DuplicateSiteNameNotAllowed : IRule
    {
        public static BrokenRuleReason SiteNameAlreadyExists = BrokenRuleReason.Create("9ceff948-f9e0-4584-9478-94a00c45b55c","Site name already exists");
        private readonly IEnumerable<Sites.Site> _sites;
        private readonly string _name;

        public DuplicateSiteNameNotAllowed(IEnumerable<Sites.Site> sites, string name)
        {
            _sites = sites;
            _name = name;
        }

        public void Evaluate(IRuleContext context, object instance)
        {
            if( _sites.Any(_ => _.Name == _name) )context.Fail(this, _name, SiteNameAlreadyExists);
        }
    }
}