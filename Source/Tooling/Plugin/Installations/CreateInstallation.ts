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
        super('152ed284-440c-45d4-acdf-763dbd869404');
        this.name = name;
        this.siteName = siteName;
    }
}