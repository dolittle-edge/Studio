/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
import { Command, CommandContext, IFailedCommandOutputter } from "@dolittle/tooling.common.commands";
import { IDependencyResolvers, PromptDependency, argumentUserInputType, IsNotEmpty } from "@dolittle/tooling.common.dependencies";
import { ICanOutputMessages, IBusyIndicator } from "@dolittle/tooling.common.utilities";
import { requireInternet, IConnectionChecker} from "@dolittle/tooling.common.packages";
import { CommandCoordinator } from "@dolittle/commands";
import { RegisterNodeWithInstallation } from "../../internal";

const name = 'node';
const description = 'register a new node with a name';

const registerPromptDependency = [
    new PromptDependency(
        'name',
        'The name of the node',
        [new IsNotEmpty()],
        argumentUserInputType,
        'The name of the node'),
    new PromptDependency(
        'installation name',
        'The name of the installation',
        [new IsNotEmpty()],
        argumentUserInputType,
        'The name of the installation'),
];

export class RegisterNodeCommand extends Command {

    constructor(private _edgeAPI: string, private _connectionChecker: IConnectionChecker, 
        private _commandCoordinator: CommandCoordinator) {
        super(name, description, false, undefined, registerPromptDependency);
    }
    
    async onAction(commandContext: CommandContext, dependencyResolvers: IDependencyResolvers,
        failedCommandOutputter: IFailedCommandOutputter, outputter: ICanOutputMessages, busyIndicator: IBusyIndicator) {
        let context = await dependencyResolvers.resolve({}, this.dependencies);
        let nodeName: any = context[registerPromptDependency[0].name];
        let installationName: any = context[registerPromptDependency[1].name];
        await requireInternet(this._connectionChecker, busyIndicator);
        CommandCoordinator.apiBaseUrl = this._edgeAPI;
        let commandResult = await this._commandCoordinator.handle(new RegisterNodeWithInstallation(nodeName, installationName));
        outputter.print(commandResult as any);
    }
}
