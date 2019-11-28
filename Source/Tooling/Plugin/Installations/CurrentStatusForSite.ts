/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated Query Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { Query } from  '@dolittle/queries';

export class CurrentStatusForSite extends Query
{
    siteName: string;

    constructor(siteName: string) {
        super('CurrentStatusForSite', 'Read.Installations.CurrentStatusForSite');
        this.siteName = siteName;
    }
}