/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
import { Command, CommandContext, IFailedCommandOutputter } from "@dolittle/tooling.common.commands";
import { IDependencyResolvers, PromptDependency, argumentUserInputType, IsNotEmpty } from "@dolittle/tooling.common.dependencies";
import { ICanOutputMessages, IBusyIndicator } from "@dolittle/tooling.common.utilities";
import { requireInternet, IConnectionChecker} from "@dolittle/tooling.common.packages";
import { CommandCoordinator } from "../../internal";
import { AddNodeToLocation } from "../../internal";
import { Guid } from "../../internal";

const name = 'node';
const description = 'Add a node to a location';

const nodePromptDependency = [
    new PromptDependency(
        'name',
        'The name of the node',
        [new IsNotEmpty()],
        argumentUserInputType,
        'The name of the node'),
    new PromptDependency(
        'locationId',
        'ID of the location',
        [new IsNotEmpty()],
        argumentUserInputType,
        'ID of the location which you want to connect the node to',
)];

export class AddNodeCommand extends Command {

    constructor(private _edgeAPI: string, private _connectionChecker: IConnectionChecker, 
        private _commandCoordinator: CommandCoordinator) {
        super(name, description, false, undefined, nodePromptDependency);
    }
    
    async onAction(commandContext: CommandContext, dependencyResolvers: IDependencyResolvers,
        failedCommandOutputter: IFailedCommandOutputter, outputter: ICanOutputMessages, busyIndicator: IBusyIndicator) {
        let context = await dependencyResolvers.resolve({}, this.dependencies);
        let name: any = context[nodePromptDependency[0].name];
        let locationId: any = context[nodePromptDependency[1].name];
        await requireInternet(this._connectionChecker, busyIndicator);
        CommandCoordinator.apiBaseUrl = this._edgeAPI;
        let commandResult = await this._commandCoordinator.handle(new AddNodeToLocation(name, Guid.create(), locationId));
        outputter.print(commandResult);
    }
}
