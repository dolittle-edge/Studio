/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated Query Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { Query } from  '@dolittle/queries';

export class LocationById extends Query
{
    locationId: string;

    constructor(locationId: string) {
        super('LocationById', 'Read.Locations.LocationById');
        this.locationId = locationId;
    }
}