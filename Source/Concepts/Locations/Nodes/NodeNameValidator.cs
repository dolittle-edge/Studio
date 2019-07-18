/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Validation;
using FluentValidation;

namespace Concepts.Locations.Nodes
{
    public class NodeNameValidator : InputValidator<NodeName>
    {
        public NodeNameValidator() 
        {
            RuleFor(_ => _)
                .NotEqual(NodeName.NotSet).WithMessage($"Node Name must not be '{NodeName.NotSet.Value.ToString()}'");
        }
    }
}