// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace API.Provisioning
{
    /// <summary>
    /// Represents the exception tat gets thrown when an a node configuration file does not exists.
    /// </summary>
    public class NodeConfigurationFileDoesNotExist : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NodeConfigurationFileDoesNotExist"/> class.
        /// </summary>
        /// <param name="path">The path for the file that is missing.</param>
        public NodeConfigurationFileDoesNotExist(string path)
            : base($"Node configuration file '{path}' doesn't exists.")
        {
        }
    }
}