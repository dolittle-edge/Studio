/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated Command Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { Command } from  '@dolittle/commands';

export class RegisterNodeWithInstallation extends Command
{
    name: string;
    installationName: String;

    constructor(name: string, installationName: string) {
        super('56442e08-5a8c-443a-8d0b-fd544b597ed6');

        this.name = name;
        this.installationName = installationName;
    }
}