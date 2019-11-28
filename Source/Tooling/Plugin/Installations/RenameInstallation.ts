/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated Command Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { Command } from  '@dolittle/commands';

export class RenameInstallation extends Command
{
    oldName: string;
    newName: string;
    siteName: string;

    constructor(oldName: string, newName: string, siteName: string) {
        super('62ad82f9-675c-4810-b7d0-0f420b31fde8');
        this.oldName = oldName;
        this.newName = newName;
        this.siteName = siteName;
    }
}