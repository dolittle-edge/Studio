// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.Installations
{
    public class CreateInstallationValidationRules : CommandInputValidatorFor<CreateInstallation>
    {
        public CreateInstallationValidationRules()
        {
            RuleFor(_ => _.Name).NotEmpty().WithMessage("Installation name can't be empty");
            RuleFor(_ => _.SiteName).NotEmpty().WithMessage("Site name can't be empty");
        }
    }
}