/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
import { CommandContext, IFailedCommandOutputter, AuthenticatedCommand } from "@dolittle/tooling.common.commands";
import { IDependencyResolvers, PromptDependency, argumentUserInputType, IsNotEmpty } from "@dolittle/tooling.common.dependencies";
import { ICanOutputMessages, IBusyIndicator } from "@dolittle/tooling.common.utilities";
import { requireInternet, IConnectionChecker} from "@dolittle/tooling.common.packages";
import { CommandCoordinator } from "@dolittle/commands";
import { RegisterSite } from "../../internal";
import { IContexts, ILoginService } from "@dolittle/tooling.common.login";

const name = 'site';
const description = 'register a new site with a name';

const registerPromptDependency = new PromptDependency(
    'site name',
    'A unique name for the site',
    [new IsNotEmpty()],
    argumentUserInputType,
    'A unique name for the site',
);

export class RegisterSiteCommand extends AuthenticatedCommand {

    constructor(private _edgeAPI: string, loginService: ILoginService, contexts: IContexts, private _connectionChecker: IConnectionChecker, 
        private _commandCoordinator: CommandCoordinator) {
        super(loginService, contexts, name, description, false, undefined, [registerPromptDependency]);
    }
    
    async onAction(commandContext: CommandContext, dependencyResolvers: IDependencyResolvers,
        failedCommandOutputter: IFailedCommandOutputter, outputter: ICanOutputMessages, busyIndicator: IBusyIndicator) {
        let context = await dependencyResolvers.resolve({}, this.dependencies);
        let name: any = context[registerPromptDependency.name];
        await requireInternet(this._connectionChecker, busyIndicator);
        CommandCoordinator.apiBaseUrl = this._edgeAPI;
        let commandResult: any = await this._commandCoordinator.handle(new RegisterSite(name));
        if (commandResult.success) {
            outputter.print(`Site '${name}' registered succesfully`)
        } else if (commandResult.hasBrokenRules) {
            commandResult.brokenRules.forEach((brokenRule: any) => {
                outputter.error(`Rules broken: ${brokenRule.rule}`);
                brokenRule.causes.forEach((cause: any) => {
                    outputter.error(`Cause: ${cause.title}`);
                });
            });
        }
    }
}
