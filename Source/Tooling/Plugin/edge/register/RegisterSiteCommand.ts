/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
import { Command, CommandContext, IFailedCommandOutputter } from "@dolittle/tooling.common.commands";
import { IDependencyResolvers, PromptDependency, argumentUserInputType, IsNotEmpty } from "@dolittle/tooling.common.dependencies";
import { ICanOutputMessages, IBusyIndicator } from "@dolittle/tooling.common.utilities";
import { requireInternet, IConnectionChecker} from "@dolittle/tooling.common.packages";
import { CommandCoordinator } from "@dolittle/commands";
import { RegisterSite } from "../../internal";

const name = 'site';
const description = 'register a new site with a name';

const registerPromptDependency = new PromptDependency(
    'name',
    'The name of the site',
    [new IsNotEmpty()],
    argumentUserInputType,
    'The name of the site'
);

export class RegisterSiteCommand extends Command {

    constructor(private _edgeAPI: string, private _connectionChecker: IConnectionChecker, 
        private _commandCoordinator: CommandCoordinator) {
        super(name, description, false, undefined, [registerPromptDependency]);
    }
    
    async onAction(commandContext: CommandContext, dependencyResolvers: IDependencyResolvers,
        failedCommandOutputter: IFailedCommandOutputter, outputter: ICanOutputMessages, busyIndicator: IBusyIndicator) {
        let context = await dependencyResolvers.resolve({}, this.dependencies);
        let name: any = context[registerPromptDependency.name];
        await requireInternet(this._connectionChecker, busyIndicator);
        CommandCoordinator.apiBaseUrl = this._edgeAPI;
        let commandResult = await this._commandCoordinator.handle(new RegisterSite(name));
        outputter.print(commandResult as any);
    }
}
