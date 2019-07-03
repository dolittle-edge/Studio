/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
import { CommandGroup, ICommand } from "@dolittle/tooling.common.commands";

const name = 'get';

const description = `Get details`;
/**
 * Represents an implementation of {ICommandGroup} for the get command group
 *
 * @export
 * @class GetCommandGroup
 * @extends {CommandGroup}
 */
export class GetCommandGroup extends CommandGroup {

    /**
     * Instantiates an instance of {GetCommandGroup}.
     * @param {ICommand[]} commands
     */
    constructor(commands: ICommand[]) {
        super(name, commands, description, false);
    }
}