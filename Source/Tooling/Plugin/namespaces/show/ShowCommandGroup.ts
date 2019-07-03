/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
import { ICommand, CommandGroup } from "@dolittle/tooling.common.commands";

const name = 'show';
const description = `Show information`;

/**
 * Represents an implementation of {ICommandGroup} 
 *
 * @export
 * @class ShowCommandGroup
 * @extends {CommandGroup}
 */
export class ShowCommandGroup extends CommandGroup {

    constructor(commands: ICommand[]) {
        super(name, commands, description, false);
    }

}
