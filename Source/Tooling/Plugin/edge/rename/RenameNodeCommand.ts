/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
import { Command, CommandContext, IFailedCommandOutputter } from "@dolittle/tooling.common.commands";
import { IDependencyResolvers, PromptDependency, argumentUserInputType, IsNotEmpty } from "@dolittle/tooling.common.dependencies";
import { ICanOutputMessages, IBusyIndicator } from "@dolittle/tooling.common.utilities";
import { requireInternet, IConnectionChecker} from "@dolittle/tooling.common.packages";
import { CommandCoordinator } from "@dolittle/commands";
import { RenameNode } from "../../internal";

const name = 'node';

const description = `Display detailed information of a node`;

const renameNodePropmtDependencies = [
        new PromptDependency(
        'current name',
        'current name of the node',
        [new IsNotEmpty()],
        argumentUserInputType,
        'current name of the node'
    ),
        new PromptDependency(
        'new name',
        'new name of the node',
        [new IsNotEmpty()],
        argumentUserInputType,
        'new name of the node'
    )
];

export class RenameNodeCommand extends Command {

    constructor(private _edgeAPI: string, private _connectionChecker: IConnectionChecker,
           private _commandCoordinator : CommandCoordinator) {
        super(name, description, false, undefined, renameNodePropmtDependencies);
    }
    async onAction(commandContext: CommandContext, dependencyResolvers: IDependencyResolvers, failedCommandOutputter: IFailedCommandOutputter, outputter: ICanOutputMessages, busyIndicator: IBusyIndicator) {
        let context = await dependencyResolvers.resolve({}, this.dependencies);
        let oldName: any = context[renameNodePropmtDependencies[0].name];
        let newName: any = context[renameNodePropmtDependencies[1].name];
        await requireInternet(this._connectionChecker, busyIndicator);
        CommandCoordinator.apiBaseUrl = this._edgeAPI;
        let commandResult = await this._commandCoordinator.handle(new RenameNode(oldName, newName));
        outputter.print(commandResult as any);
    }
}
