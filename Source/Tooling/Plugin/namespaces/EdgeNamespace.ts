/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
import { Namespace, ICommandGroup, ICommand } from "@dolittle/tooling.common.commands";

const name = 'edge';
const description = 'The edge namespace';

export class EdgeNamespace extends Namespace {

    constructor(commands: ICommand[], commandGroups: ICommandGroup[]) {
        super(name, commands, commandGroups, description);

    }
}