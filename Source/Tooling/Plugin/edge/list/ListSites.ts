/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
import { Command, CommandContext, IFailedCommandOutputter, AuthenticatedCommand } from "@dolittle/tooling.common.commands";
import { IDependencyResolvers, PromptDependency, argumentUserInputType, IsNotEmpty } from "@dolittle/tooling.common.dependencies";
import { ICanOutputMessages, IBusyIndicator } from "@dolittle/tooling.common.utilities";
import { requireInternet, IConnectionChecker} from "@dolittle/tooling.common.packages";
import { QueryCoordinator } from "@dolittle/queries";
import { AllSites } from "../../internal";
import { StatusForAllSites } from "../../internal";
import dateformat from 'dateformat';
import { IContexts, ILoginService } from "@dolittle/tooling.common.login";

const name = 'sites';

const description = `List all registered sites`;

export class ListSites extends AuthenticatedCommand {

    constructor(private _edgeAPI: string, loginService: ILoginService, contexts: IContexts, private _connectionChecker: IConnectionChecker,
           private _queryCoordinator: QueryCoordinator) {
        super(loginService, contexts, name, description, false, undefined);
    }
    async onAction(commandContext: CommandContext, dependencyResolvers: IDependencyResolvers, failedCommandOutputter: IFailedCommandOutputter, outputter: ICanOutputMessages, busyIndicator: IBusyIndicator) {
        await requireInternet(this._connectionChecker, busyIndicator);
        QueryCoordinator.apiBaseUrl = this._edgeAPI;
        let result = await this._queryCoordinator.execute(new StatusForAllSites());
        let results = result.items;
        let formatted: any[] = results.map((site: any) => ({
                'Name': site.name,
                'Connected/Total Nodes': `${site.connectedNodes} / ${site.totalNodes}`,
                'Threshold': site.threshold,
                'Last seen nodes': site.lastSeenNodes ? site.lastSeenNodes : 'never',
                'Last seen': dateformat(site.LastSeen, 'HH:MM dd.mm.yyyy')
        }));
        outputter.table(formatted);
    }
}
