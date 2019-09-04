/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Concepts;

namespace Concepts.Telemetry
{

    /// <summary>
    /// Represents the sample of an <see cref="Info"/>
    /// </summary>
    public class Info : ConceptAs<string>
    {
        /// <summary>
        /// Convert from float to a <see cref="Info"/> 
        /// </summary>
        /// <param name="value">Value to convert from</param>
        public static implicit operator Info(string value)
        {
            return new Info { Value = value };
        }
    }
}