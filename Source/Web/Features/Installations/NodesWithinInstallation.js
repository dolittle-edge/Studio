/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated Query Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { Query } from  '@dolittle/queries';

export class NodesWithinInstallation extends Query
{
    constructor() {
        super();
        this.nameOfQuery = 'NodesWithinInstallation';
        this.generatedFrom = 'Read.Installations.NodesWithinInstallation';

        this.installationName = '';
        this.siteName = '';
    }
}