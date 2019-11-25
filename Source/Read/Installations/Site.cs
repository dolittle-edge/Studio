/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Concepts.Installations;
using Dolittle.ReadModels;

namespace Read.Installations
{
    public class Site : IReadModel
    {
        public SiteId Id { get; set; }

        public string Name { get; set; }
    }
}