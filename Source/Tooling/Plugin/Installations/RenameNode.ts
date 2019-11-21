/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated Command Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { Command } from  '@dolittle/commands';

export class RenameNode extends Command
{
    oldName: string;
    newName: string;

    constructor(oldName: string, newName: string) {
        super('a93f2a72-9dea-42f4-b8a5-87c322678671');
        this.oldName = oldName;
        this.newName = newName;
    }
}