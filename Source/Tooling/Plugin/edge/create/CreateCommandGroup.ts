/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
import { ICommand, CommandGroup } from "@dolittle/tooling.common.commands";

const name = 'create';
const description = `create an installation`;

/**
 * Represents an implementation of {ICommandGroup} 
 *
 * @export
 * @class CreateCommandGroup
 * @extends {CommandGroup}
 */
export class CreateCommandGroup extends CommandGroup {

    constructor(commands: ICommand[]) {
        super(name, commands, description, false);
    }

}
