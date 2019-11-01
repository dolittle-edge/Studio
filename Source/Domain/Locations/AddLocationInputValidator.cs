/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.Locations
{
    public class AddLocationInputValidator : CommandInputValidatorFor<AddLocation>
    {
        public AddLocationInputValidator() 
        {
            RuleFor(_=>_.Name).NotEmpty().WithMessage("Name is required");
        }
    }
}