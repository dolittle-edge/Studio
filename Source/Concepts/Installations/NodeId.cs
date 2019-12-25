// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Dolittle.Concepts;
using Dolittle.Runtime.Events;

namespace Concepts.Installations
{
    /// <summary>
    /// Represents the unique identifier of a node.
    /// </summary>
    public class NodeId : ConceptAs<Guid>
    {
        /// <summary>
        /// Implicitly convert from a <see cref="Guid"/> to a <see cref="NodeId"/>.
        /// </summary>
        /// <param name="value"><see cref="Guid"/> to convert from.</param>
        public static implicit operator NodeId(Guid value) => new NodeId { Value = value };

        /// <summary>
        /// Implicitly convert from a <see cref="NodeId"/> to a <see cref="EventSourceId"/>.
        /// </summary>
        /// <param name="id"><see cref="NodeId"/> to convert from.</param>
        public static implicit operator EventSourceId(NodeId id) => new EventSourceId { Value = id.Value };
    }
}
