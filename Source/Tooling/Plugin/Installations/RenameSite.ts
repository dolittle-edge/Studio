/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated Command Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { Command } from  '@dolittle/commands';

export class RenameSite extends Command
{
    oldName: string;
    newName: string;

    constructor(oldName: string, newName: string) {
        super('6156d018-a87e-43a4-bd72-7ce7e4c76f27');
        this.oldName = oldName;
        this.newName = newName;
    }
}