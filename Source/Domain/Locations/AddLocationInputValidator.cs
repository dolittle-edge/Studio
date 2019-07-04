/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Commands.Validation;
using Concepts.Locations;
using FluentValidation;

namespace Domain.Locations
{
    public class AddLocationInputValidator : CommandInputValidatorFor<AddLocation>
    {
        AddLocationInputValidator()
        {
            RuleForConcept(_ => _.Id)
                .NotNull().WithMessage("Id is required")
                .SetValidator(new LocationIdValidator());
            RuleForConcept(_ => _.Name)
                .NotNull().WithMessage("Location name is required")
                .SetValidator(new LocationNameValidator());
        }
    }
}
