/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
import { ICommand, CommandGroup } from "@dolittle/tooling.common.commands";

const name = 'rename';
const description = `Rename a resource's name`;

/**
 * Represents an implementation of {ICommandGroup} 
 *
 * @export
 * @class RenameCommandGroup
 * @extends {CommandGroup}
 */
export class RenameCommandGroup extends CommandGroup {

    constructor(commands: ICommand[]) {
        super(name, commands, description, false);
    }
}
