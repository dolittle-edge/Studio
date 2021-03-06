/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
import { Command, CommandContext, IFailedCommandOutputter, AuthenticatedCommand } from "@dolittle/tooling.common.commands";
import { IDependencyResolvers, PromptDependency, argumentUserInputType, IsNotEmpty } from "@dolittle/tooling.common.dependencies";
import { ICanOutputMessages, IBusyIndicator, Exception } from "@dolittle/tooling.common.utilities";
import { requireInternet, IConnectionChecker} from "@dolittle/tooling.common.packages";
import { CommandCoordinator } from "@dolittle/commands";
import { ILoginService, IContexts } from "@dolittle/tooling.common.login";

const name = 'installation';
const description = 'deletes an installation';

const deletePromptDependency = new PromptDependency(
    'name',
    'The name of the installation',
    [new IsNotEmpty()],
    argumentUserInputType,
    'The name of the installation'
);

export class DeleteInstallationCommand extends AuthenticatedCommand {

    constructor(private _edgeAPI: string, loginService: ILoginService, contexts: IContexts, private _connectionChecker: IConnectionChecker, 
        private _commandCoordinator: CommandCoordinator) {
        super(loginService, contexts, name, description, false, undefined, [deletePromptDependency]);
    }
    
    async onAction(commandContext: CommandContext, dependencyResolvers: IDependencyResolvers,
        failedCommandOutputter: IFailedCommandOutputter, outputter: ICanOutputMessages, busyIndicator: IBusyIndicator) {
        let context = await dependencyResolvers.resolve({}, this.dependencies);
        // let name: any = context[deletePromptDependency[0].name];
        // let siteName: any = context[deletePromptDependency[1].name];
        await requireInternet(this._connectionChecker, busyIndicator);
        CommandCoordinator.apiBaseUrl = this._edgeAPI;
        // TODO: add the real logic here
        // let commandResult = await this._commandCoordinator.handle(new AddNodeToLocation(name, Guid.create(), locationId));
        // outputter.print(commandResult as any);
        throw new Exception('Unimplemented command');
    }
}
