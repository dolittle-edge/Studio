/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Concepts;

namespace Concepts.Telemetry
{
    /// <summary>
    /// Represents the concept of a type of a metric
    /// </summary>
    public class InfoType : ConceptAs<string>
    {
        /// <summary>
        /// Implicitly convert from <see cref="string"/> to <see cref="InfoType"/>
        /// </summary>
        /// <param name="type"><see cref="string"/> to convert from</param>
        public static implicit operator InfoType(string type)
        {
            return new InfoType { Value = type };
        }        
    }
}