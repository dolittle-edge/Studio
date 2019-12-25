/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated Command Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { Command } from '@dolittle/commands';

export class AddLocation extends Command
{
    locationId: string;
    name: string;

    constructor(name: string, locationId: string) {
        super('81068b8b-40cd-462c-b616-35ab7c17047c');
        this.locationId = locationId;
        this.name = name;
    }
}