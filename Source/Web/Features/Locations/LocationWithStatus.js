/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated ReadModel Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { ReadModel } from  '@dolittle/readmodels';

export class LocationWithStatus extends ReadModel
{
    constructor() {
        super();
        this.artifact = {
           id: 'f3264133-b0fc-4193-bab4-73da748b184a',
           generation: '1'
        };
        this.id = '00000000-0000-0000-0000-000000000000';
        this.name = '';
        this.connectedNodes = 0;
        this.totalNodes = 0;
        this.nodes = [];
        this.lastSeen = new Date();
        this.hasBeenSeen = false;
    }
}