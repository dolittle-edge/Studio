/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
import { ICommand, CommandGroup } from "@dolittle/tooling.common.commands";

const name = 'describe';
const description = `Display detailed information state of a resource`;

/**
 * Represents an implementation of {ICommandGroup} 
 *
 * @export
 * @class DescribeCommandGroup
 * @extends {CommandGroup}
 */
export class DescribeCommandGroup extends CommandGroup {

    constructor(commands: ICommand[]) {
        super(name, commands, description, false);
    }

}
