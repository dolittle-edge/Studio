/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated Query Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { Query } from  '../internal';

export class LocationById extends Query
{
    nameOfQuery: string;
    generatedFrom: string;
    locationId: string;

    constructor(locationId: string) {
        super();
        this.nameOfQuery = 'LocationById';
        this.generatedFrom = 'Read.Locations.LocationById';

        this.locationId = locationId;
        // this.locationId = '00000000-0000-0000-0000-000000000000';
    }
}