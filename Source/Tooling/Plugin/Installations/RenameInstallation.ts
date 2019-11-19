/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated Command Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { Command } from  '@dolittle/commands';

export class RenameInstallation extends Command
{
    oldName: string;
    newName: string;

    constructor(oldName: string, newName: string) {
        super('7384a27b-e5af-4c8f-a5b4-04b439b29ce7');
        this.oldName = oldName;
        this.newName = newName;
    }
}