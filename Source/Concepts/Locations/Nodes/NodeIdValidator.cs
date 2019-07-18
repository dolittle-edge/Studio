/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Validation;
using FluentValidation;

namespace Concepts.Locations.Nodes
{
    public class NodeIdValidator : InputValidator<NodeId>
    {
        public NodeIdValidator() 
        {
            RuleFor(_ => _)
                .NotEqual(NodeId.NotSet).WithMessage($"Node Id must not be '{NodeId.NotSet.Value.ToString()}'");
        }
    }
}