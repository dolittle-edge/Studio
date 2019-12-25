/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated Query Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { Query } from  '@dolittle/queries';

export class NodesWithinInstallation extends Query
{
    installationName: string;
    siteName: string;

    constructor(installationName: string, siteName: string) {
        super('NodesWithinInstallation', 'Read.Installations.NodesWithinInstallation');
        this.installationName = installationName;
        this.siteName = siteName;
    }
}