/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Concepts.Locations;

namespace Domain.Locations
{
    public delegate bool NameMustBeUnique(LocationName name);
    public delegate bool NotExist(LocationId id);
}