/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated Command Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { Command } from  '@dolittle/commands';

export class CreateInstallation extends Command
{
    name: string;
    siteName: string;

    constructor(name: string, siteName: string) {
        super('7f0fdd84-e22f-4297-815a-ddf2fa6d4526');
        // super('7f0fdd84-e22f-4297-815a-ddf2fa6d4526');
        this.name = name;
        this.siteName = siteName;
    }
}