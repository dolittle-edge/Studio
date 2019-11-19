/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
import { ICommand, CommandGroup } from "@dolittle/tooling.common.commands";

const name = 'add';
const description = `add a node to installation`;

/**
 * Represents an implementation of {ICommandGroup} 
 *
 * @export
 * @class AddCommandGroup
 * @extends {CommandGroup}
 */
export class AddCommandGroup extends CommandGroup {

    constructor(commands: ICommand[]) {
        super(name, commands, description, false);
    }

}
