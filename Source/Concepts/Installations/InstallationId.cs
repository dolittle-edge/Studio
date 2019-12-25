// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Dolittle.Concepts;
using Dolittle.Runtime.Events;

namespace Concepts.Installations
{
    /// <summary>
    /// Represents the unique identifier of an installation.
    /// </summary>
    public class InstallationId : ConceptAs<Guid>
    {
        /// <summary>
        /// Implicitly convert from a <see cref="Guid"/> to a <see cref="InstallationId"/>.
        /// </summary>
        /// <param name="value"><see cref="Guid"/> to convert from.</param>
        public static implicit operator InstallationId(Guid value) => new InstallationId { Value = value };

        /// <summary>
        /// Implicitly convert from a <see cref="InstallationId"/> to a <see cref="EventSourceId"/>.
        /// </summary>
        /// <param name="id"><see cref="InstallationId"/> to convert from.</param>
        public static implicit operator EventSourceId(InstallationId id) => new EventSourceId { Value = id.Value };
    }
}
