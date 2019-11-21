/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
import { CommandContext, IFailedCommandOutputter, AuthenticatedCommand } from "@dolittle/tooling.common.commands";
import { IDependencyResolvers, PromptDependency, argumentUserInputType, IsNotEmpty } from "@dolittle/tooling.common.dependencies";
import { ICanOutputMessages, IBusyIndicator } from "@dolittle/tooling.common.utilities";
import { requireInternet, IConnectionChecker} from "@dolittle/tooling.common.packages";
import { CommandCoordinator } from "@dolittle/commands";
import { RenameSite } from "../../internal";
import { IContexts, ILoginService } from "@dolittle/tooling.common.login";

const name = 'site';

const description = `Display detailed information of a site`;

const renameSitePromptDependencies = [
        new PromptDependency(
        'current name',
        'current name of the site',
        [new IsNotEmpty()],
        argumentUserInputType,
        'current name of the site'
    ),
        new PromptDependency(
        'new name',
        'new name of the site',
        [new IsNotEmpty()],
        argumentUserInputType,
        'new name of the site'
    )
];

export class RenameSiteCommand extends AuthenticatedCommand {

    constructor(private _edgeAPI: string, loginService: ILoginService, contexts: IContexts, private _connectionChecker: IConnectionChecker,
           private _commandCoordinator : CommandCoordinator) {
        super(loginService, contexts, name, description, false, undefined, renameSitePromptDependencies);
    }
    async onAction(commandContext: CommandContext, dependencyResolvers: IDependencyResolvers, failedCommandOutputter: IFailedCommandOutputter, outputter: ICanOutputMessages, busyIndicator: IBusyIndicator) {
        let context = await dependencyResolvers.resolve({}, this.dependencies);
        let oldName: any = context[renameSitePromptDependencies[0].name];
        let newName: any = context[renameSitePromptDependencies[1].name];
        await requireInternet(this._connectionChecker, busyIndicator);
        CommandCoordinator.apiBaseUrl = this._edgeAPI;
        let commandResult = await this._commandCoordinator.handle(new RenameSite(oldName, newName));
        outputter.print(commandResult as any);
    }
}
