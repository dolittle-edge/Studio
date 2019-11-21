/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated Query Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { Query } from  '@dolittle/queries';

export class InstallationsOnSite extends Query
{
    siteName: string;

    constructor(siteName: string) {
        super('InstallationsOnSite', 'Read.Installations.InstallationsOnSite');
        this.siteName = siteName;
    }
}