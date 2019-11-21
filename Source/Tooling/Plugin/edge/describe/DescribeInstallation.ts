/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
import { Command, CommandContext, IFailedCommandOutputter, AuthenticatedCommand } from "@dolittle/tooling.common.commands";
import { IDependencyResolvers, PromptDependency, argumentUserInputType, IsNotEmpty } from "@dolittle/tooling.common.dependencies";
import { ICanOutputMessages, IBusyIndicator } from "@dolittle/tooling.common.utilities";
import { requireInternet, IConnectionChecker} from "@dolittle/tooling.common.packages";
import { QueryCoordinator } from "@dolittle/queries";

import dateformat from 'dateformat';
import { ILoginService, IContexts } from "@dolittle/tooling.common.login";

const name = 'installation';

const description = `Display detailed information of an installation`;

const nameDependency = new PromptDependency(
    'installation name',
    'name of the installation',
    [new IsNotEmpty()],
    argumentUserInputType,
    'name of the installation'
);

export class DescribeInstallation extends AuthenticatedCommand {

    constructor(private _edgeAPI: string, loginService: ILoginService, contexts: IContexts, private _connectionChecker: IConnectionChecker,
           private _queryCoordinator: QueryCoordinator) {
        super(loginService, contexts, name, description, false, undefined);
    }
    async onAction(commandContext: CommandContext, dependencyResolvers: IDependencyResolvers, failedCommandOutputter: IFailedCommandOutputter, outputter: ICanOutputMessages, busyIndicator: IBusyIndicator) {
/*         let context = await dependencyResolvers.resolve({}, this.dependencies);
        let locationId: any = context[nameDependency.name];
        await requireInternet(this._connectionChecker, busyIndicator);
        QueryCoordinator.apiBaseUrl = this._edgeAPI;
        let commandResult = await this._queryCoordinator.execute(new LocationById(locationId));
        let results = commandResult.items;
        outputter.print(results as any);
        let formatted: any[] = results.map((location: any) => ({
                'Id': location.id,
                'Name': location.name,
                'Nodes': `${location.connectedNodes}/${location.totalNodes}`,
                'Last Seen': location.hasBeenSeen ? dateformat(location.lastSeen, 'yyyy-mm-dd HH:MM:ss') : 'never'
        }));
        outputter.table(formatted); */
    }
}
