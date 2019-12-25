// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

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
        /// Gets or sets manufacturer of the node hardware.
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets identifies the family to which the node hardware belongs.
        /// </summary>
        public string Family { get; set; }

        /// <summary>
        /// Gets or sets identitifies the particular product of the node hardware.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets idientifies the version of the node hardware product.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets identifies a particular configuration of the node hardware for sale.
        /// </summary>
        public string SKUNumber { get; set; }

        /// <summary>
        /// Gets or sets the serial number uniquely identifying the node hardware instance.
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Gets or sets a unique identifier for the node hardware instance.
        /// </summary>
        public Guid UUID { get; set; }
    }
}