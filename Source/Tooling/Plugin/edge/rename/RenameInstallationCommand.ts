/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
import { CommandContext, IFailedCommandOutputter, AuthenticatedCommand } from "@dolittle/tooling.common.commands";
import { IDependencyResolvers, PromptDependency, argumentUserInputType, IsNotEmpty } from "@dolittle/tooling.common.dependencies";
import { ICanOutputMessages, IBusyIndicator } from "@dolittle/tooling.common.utilities";
import { requireInternet, IConnectionChecker} from "@dolittle/tooling.common.packages";
import { CommandCoordinator } from "@dolittle/commands";
import { RenameInstallation, DolittleOutputter } from "../../internal";
import { IContexts, ILoginService } from "@dolittle/tooling.common.login";

const name = 'installation';

const description = `Rename an installation inside a site`;

const renameInstallationPromptDependencies = [
    new PromptDependency(
        'current name',
        'current name of the installation',
        [new IsNotEmpty()],
        argumentUserInputType,
        'current name of the installation'
    ),
    new PromptDependency(
        'new name',
        'new name of the installation',
        [new IsNotEmpty()],
        argumentUserInputType,
        'new name of the installation'
    ),
    new PromptDependency(
        'site name',
        'name of the site',
        [new IsNotEmpty()],
        argumentUserInputType,
        'name of the site'
)];

export class RenameInstallationCommand extends AuthenticatedCommand {

    constructor(private _edgeAPI: string, loginService: ILoginService, contexts: IContexts, private _connectionChecker: IConnectionChecker,
           private _commandCoordinator : CommandCoordinator) {
        super(loginService, contexts, name, description, false, undefined, renameInstallationPromptDependencies);
    }
    async onAction(commandContext: CommandContext, dependencyResolvers: IDependencyResolvers, failedCommandOutputter: IFailedCommandOutputter, outputter: ICanOutputMessages, busyIndicator: IBusyIndicator) {
        outputter = new DolittleOutputter();
        let context = await dependencyResolvers.resolve({}, this.dependencies);
        let oldName: any = context[renameInstallationPromptDependencies[0].name];
        let newName: any = context[renameInstallationPromptDependencies[1].name];
        let siteName: any = context[renameInstallationPromptDependencies[2].name];
        await requireInternet(this._connectionChecker, busyIndicator);
        CommandCoordinator.apiBaseUrl = this._edgeAPI;
        let commandResult: any = await this._commandCoordinator.handle(new RenameInstallation(oldName, newName, siteName));
        const successString: string = `Installation '${oldName}' renamed to '${newName}' at site '${siteName}'`;
        const failString: string = `Error while renaming installation '${oldName}' to '${newName}' at site '${siteName}'`;
        outputter.print(commandResult, successString, failString);
    }
}
