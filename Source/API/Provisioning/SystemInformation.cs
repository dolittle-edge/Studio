/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;

namespace API.Provisioning
{
    /// <summary>
    /// Represents system information coded in the BIOS of a node.
    /// See the 'System Management BIOS (SMBIOS) Reference Specification', document identifier DSP0134.
    /// </summary>
    public class SystemInformation
    {
        /// <summary>
        /// Manufacturer of the node hardware
        /// </summary>
        public string Manufacturer { get; set; }
        /// <summary>
        /// Identifies the family to which the node hardware belongs
        /// </summary>
        public string Family { get; set; }
        /// <summary>
        /// Identitifies the particular product of the node hardware
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// Idientifies the version of the node hardware product
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// Identifies a particular configuration of the node hardware for sale 
        /// </summary>
        public string SKUNumber { get; set; }
        /// <summary>
        /// The serial number uniquely identifying the node hardware instance
        /// </summary>
        public string SerialNumber { get; set; }
        /// <summary>
        /// A unique identifier for the node hardware instance
        /// </summary>
        public Guid UUID { get; set; }
    }
}