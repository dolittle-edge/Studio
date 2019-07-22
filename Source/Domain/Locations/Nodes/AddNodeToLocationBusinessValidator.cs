/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.Locations.Nodes
{
    public class AddNodeToLocationBusinessValidator : CommandBusinessValidatorFor<AddNodeToLocation>
    {
        public AddNodeToLocationBusinessValidator() //NotExist notExist, NameMustBeUnique beUnique)
        {
            /*
            RuleFor(_ => _.Id)
                .Must(_ => notExist(_)).WithMessage(_ => $"Node with id '${_.Id.Value.ToString()} already exists'");
            RuleFor(_ => _.Name)
                .Must(_ => beUnique(_)).WithMessage(_ => $"Node with name '${_.Name.Value}' already exists");*/
        }
    }
}
