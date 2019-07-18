/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Concepts;

namespace Concepts.Telemetry
{
    /// <summary>
    /// Represents the sample of a <see cref="TelemetryType"/>
    /// </summary>
    public class TelemetrySample : ConceptAs<float>
    {
        /// <summary>
        /// Implicitly convert from float to a <see cref="TelemetryType"/> 
        /// </summary>
        /// <param name="value">Value to convert from</param>
        public static implicit operator TelemetrySample(float value)
        {
            return new TelemetrySample { Value = value };
        }
    }
}