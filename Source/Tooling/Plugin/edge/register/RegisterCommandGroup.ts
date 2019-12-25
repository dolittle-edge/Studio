/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
import { ICommand, CommandGroup } from "@dolittle/tooling.common.commands";

const name = 'register';
const description = `register a new physical resource like a site or node`;

/**
 * Represents an implementation of {ICommandGroup} 
 *
 * @export
 * @class RenameCommandGroup
 * @extends {CommandGroup}
 */
export class RegisterCommandGroup extends CommandGroup {

    constructor(commands: ICommand[]) {
        super(name, commands, description, false);
    }

}
