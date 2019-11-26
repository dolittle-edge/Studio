/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
import { Command, CommandContext, IFailedCommandOutputter, AuthenticatedCommand } from "@dolittle/tooling.common.commands";
import { IDependencyResolvers, PromptDependency, argumentUserInputType, IsNotEmpty } from "@dolittle/tooling.common.dependencies";
import { ICanOutputMessages, IBusyIndicator } from "@dolittle/tooling.common.utilities";
import { requireInternet, IConnectionChecker} from "@dolittle/tooling.common.packages";
import { CommandCoordinator } from "@dolittle/commands";
import { CreateInstallation, DolittleOutputter } from "../../internal";
import { ILoginService, IContexts } from "@dolittle/tooling.common.login";

const name = 'installation';
const description = 'create a new installation connected to a site';

const createPromptDependency = [
    new PromptDependency(
        'name',
        'The name of the installation',
        [new IsNotEmpty()],
        argumentUserInputType,
        'The name of the installation'),
    new PromptDependency(
        'siteName',
        'name of the site',
        [new IsNotEmpty()],
        argumentUserInputType,
        'name of the site you want to create the installation for',
)];

export class CreateInstallationCommand extends AuthenticatedCommand {

    constructor(private _edgeAPI: string, loginService: ILoginService, contexts: IContexts, private _connectionChecker: IConnectionChecker, 
        private _commandCoordinator: CommandCoordinator) {
        super(loginService, contexts, name, description, false, undefined, createPromptDependency);
    }
    
    async onAction(commandContext: CommandContext, dependencyResolvers: IDependencyResolvers,
        failedCommandOutputter: IFailedCommandOutputter, outputter: ICanOutputMessages, busyIndicator: IBusyIndicator) {
        outputter = new DolittleOutputter();
        let context = await dependencyResolvers.resolve({}, this.dependencies);
        let installationName: string = context[createPromptDependency[0].name];
        let siteName: string = context[createPromptDependency[1].name];
        await requireInternet(this._connectionChecker, busyIndicator);
        CommandCoordinator.apiBaseUrl = this._edgeAPI;
        let commandResult: any = await this._commandCoordinator.handle(new CreateInstallation(installationName, siteName));
        const successString: string = `Installation '${installationName}' created to site '${siteName}'`;
        const failString: string = `Error while creating installation '${installationName}' to site '${siteName}}'`;
        outputter.print(commandResult, successString, failString);
    }
}
