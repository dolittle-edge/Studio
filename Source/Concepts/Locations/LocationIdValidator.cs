/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Validation;
using FluentValidation;

namespace Concepts.Locations
{
    public class LocationIdValidator : InputValidator<LocationId>
    {
        public LocationIdValidator() 
        {
            RuleFor(_ => _)
                .NotEqual(LocationId.NotSet).WithMessage($"Location Id must not be '{LocationId.NotSet.Value.ToString()}'");
        }
    }
}