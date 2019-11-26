/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
import { CommandContext, IFailedCommandOutputter, AuthenticatedCommand } from "@dolittle/tooling.common.commands";
import { IDependencyResolvers, PromptDependency, argumentUserInputType, IsNotEmpty } from "@dolittle/tooling.common.dependencies";
import { ICanOutputMessages, IBusyIndicator } from "@dolittle/tooling.common.utilities";
import { requireInternet, IConnectionChecker} from "@dolittle/tooling.common.packages";
import { CommandCoordinator } from "@dolittle/commands";
import { IContexts, ILoginService } from "@dolittle/tooling.common.login";
import { RegisterNodeWithInstallation, DolittleOutputter } from "../../internal";

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
    new PromptDependency(
        'site name',
        'The name of the site',
        [new IsNotEmpty()],
        argumentUserInputType,
        'The name of the site')
];

export class RegisterNodeCommand extends AuthenticatedCommand {

    constructor(private _edgeAPI: string, loginService: ILoginService, contexts: IContexts, private _connectionChecker: IConnectionChecker, 
        private _commandCoordinator: CommandCoordinator) {
        super(loginService, contexts, name, description, false, undefined, registerPromptDependency);
    }
    
    async onAction(commandContext: CommandContext, dependencyResolvers: IDependencyResolvers, failedCommandOutputter: IFailedCommandOutputter, outputter: ICanOutputMessages, busyIndicator: IBusyIndicator) {
        let context = await dependencyResolvers.resolve({}, this.dependencies);
        outputter = new DolittleOutputter();
        let nodeName: any = context[registerPromptDependency[0].name];
        let installationName: any = context[registerPromptDependency[1].name];
        let siteName: any = context[registerPromptDependency[2].name];
        await requireInternet(this._connectionChecker, busyIndicator);
        CommandCoordinator.apiBaseUrl = this._edgeAPI;
        let commandResult: any = await this._commandCoordinator.handle(new RegisterNodeWithInstallation(nodeName, installationName, siteName));
        const successString: string = `Node '${nodeName}' registered succesfully to '${installationName}' at '${siteName}'`;
        const failString: string = `Error while registering node '${nodeName}' to '${installationName}' at '${siteName}'`;
        outputter.print(commandResult, successString, failString);
    }
}
