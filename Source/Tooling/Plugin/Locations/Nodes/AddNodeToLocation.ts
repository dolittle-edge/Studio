/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated Command Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { Command } from  '@dolittle/commands';

export class AddNodeToLocation extends Command
{
    id: string;
    locationId: string;
    name: string;

    constructor(name: string, id: string, locationId: string) {
        super('0b01988d-cd11-4173-8872-0b4cbc45283e');
        this.name = name;
        this.id = id;
        this.locationId = locationId;
    }
}