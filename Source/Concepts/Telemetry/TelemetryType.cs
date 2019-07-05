/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Concepts;

namespace Concepts.Telemetry
{
    /// <summary>
    /// Represents the concept of a type of telemetry
    /// </summary>
    public class TelemetryType : ConceptAs<string>
    {
        /// <summary>
        /// Implicitly convert from <see cref="string"/> to <see cref="TelemetryType"/>
        /// </summary>
        /// <param name="type"><see cref="string"/> to convert from</param>
        public static implicit operator TelemetryType(string type)
        {
            return new TelemetryType { Value = type };
        }        
    }
}