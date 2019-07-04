/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Validation;
using FluentValidation;

namespace Concepts.Locations
{
    public class LocationNameValidator : InputValidator<LocationName>
    {
        public LocationNameValidator() 
        {
            RuleFor(_ => _)
                .NotEqual(LocationName.NotSet).WithMessage($"Location name must not be '{LocationName.NotSet.Value.ToString()}'");
        }
    }
}