/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Booting;

namespace API.Telemetry
{
    /// <summary>
    /// 
    /// </summary>
    public class LocationStatusesBootProcedure : ICanPerformBootProcedure
    {
        readonly ILocationStatuses _locationStatuses;

        /// <summary>
        /// Initializes a new instance of <see cref="LocationStatusesBootProcedure"/>
        /// </summary>
        /// <param name="locationStatuses"><see cref="ILocationStatuses"/> to initialize</param>
        public LocationStatusesBootProcedure(ILocationStatuses locationStatuses)
        {
            _locationStatuses = locationStatuses;
        }


        /// <inheritdoc/>
        public bool CanPerform() => true;

        /// <inheritdoc/>
        public void Perform()
        {
            _locationStatuses.Initialize();
        }
    }
}