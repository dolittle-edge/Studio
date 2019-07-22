/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Concepts.Locations;
using Concepts.Locations.Nodes;
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.Locations.Nodes
{
    public class AddNodeToLocationInputValidator : CommandInputValidatorFor<AddNodeToLocation>
    {
        public AddNodeToLocationInputValidator()
        {
            /*
            RuleForConcept(_ => _.Id)
                .NotNull().WithMessage("Id is required")
                .SetValidator(new NodeIdValidator());
            RuleForConcept(_ => _.LocationId)
                .NotNull().WithMessage("Location Id is required")
                .SetValidator(new LocationIdValidator());
            RuleForConcept(_ => _.Name)
                .NotNull().WithMessage("Node Name is required")
                .SetValidator(new NodeNameValidator());*/
        }
    }
}
