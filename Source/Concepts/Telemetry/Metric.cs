/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Concepts;

namespace Concepts.Telemetry
{

    /// <summary>
    /// Represents the sample of a <see cref="Metric"/>
    /// </summary>
    public class Metric : ConceptAs<float>
    {
        /// <summary>
        /// Convert from float to a <see cref="Metric"/> 
        /// </summary>
        /// <param name="value">Value to convert from</param>
        public static implicit operator Metric(float value)
        {
            return new Metric { Value = value };
        }
    }
}