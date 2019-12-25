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
        super('15dbeb7f-ddbc-4ae4-b48a-e5e673687b57');
        this.oldName = oldName;
        this.newName = newName;
    }
}