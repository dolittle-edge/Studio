/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using System.Linq;
using Dolittle.Rules;

namespace Domain.Installations
{
    public class SiteMustExist : IRule
    {
        public static BrokenRuleReason SiteWithNameDoesNotExists = BrokenRuleReason.Create("60c1f7be-3937-4625-a23a-1842e411ac55","Site with name does not exist");
        private readonly IEnumerable<Sites.Site> _sites;
        private readonly string _name;

        public SiteMustExist(IEnumerable<Sites.Site> sites, string name)
        {
            _sites = sites;
            _name = name;
        }

        public void Evaluate(IRuleContext context, object instance)
        {
            if( !_sites.Any(_ => _.Name == _name) )context.Fail(this, _name, SiteWithNameDoesNotExists);
        }
    }
}