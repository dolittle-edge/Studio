/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
import { ICommand, CommandGroup } from "@dolittle/tooling.common.commands";

const name = 'list';
const description = `List out all particular resources`;

/**
 * Represents an implementation of {ICommandGroup} 
 *
 * @export
 * @class ListCommandGroup
 * @extends {CommandGroup}
 */
export class ListCommandGroup extends CommandGroup {

    constructor(commands: ICommand[]) {
        super(name, commands, description, false);
    }

}
