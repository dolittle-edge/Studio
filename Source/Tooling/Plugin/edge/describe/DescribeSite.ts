/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
import { CommandContext, IFailedCommandOutputter, AuthenticatedCommand } from "@dolittle/tooling.common.commands";
import { IDependencyResolvers, PromptDependency, argumentUserInputType, IsNotEmpty } from "@dolittle/tooling.common.dependencies";
import { ICanOutputMessages, IBusyIndicator } from "@dolittle/tooling.common.utilities";
import { requireInternet, IConnectionChecker} from "@dolittle/tooling.common.packages";
import { QueryCoordinator } from "@dolittle/queries";
import { CurrentStatusForSite, InstallationsOnSite } from "../../internal";

import dateformat from 'dateformat';
import { IContexts, ILoginService } from "@dolittle/tooling.common.login";

const name = 'site';

const description = `Display detailed information of a site`;

const describeSitePromptDependency = new PromptDependency(
    'site name',
    'name of the site',
    [new IsNotEmpty()],
    argumentUserInputType,
    'name of the site'
);

export class DescribeSite extends AuthenticatedCommand {

    constructor(private _edgeAPI: string, loginService: ILoginService, contexts: IContexts, private _connectionChecker: IConnectionChecker,
           private _queryCoordinator: QueryCoordinator) {
        super(loginService, contexts, name, description, false, undefined, [describeSitePromptDependency]);
    }
    async onAction(commandContext: CommandContext, dependencyResolvers: IDependencyResolvers, failedCommandOutputter: IFailedCommandOutputter, outputter: ICanOutputMessages, busyIndicator: IBusyIndicator) {
        const context = await dependencyResolvers.resolve({}, this.dependencies);
        const siteName: any = context[describeSitePromptDependency.name];
        await requireInternet(this._connectionChecker, busyIndicator);
        QueryCoordinator.apiBaseUrl = this._edgeAPI;
        const commandResult = await this._queryCoordinator.execute(new InstallationsOnSite(siteName));
        // const commandResult = await this._queryCoordinator.execute(new CurrentStatusForSite(siteName));
        if (commandResult.items) {
            const formatted: any[] = commandResult.items.map((location: any) => ({
                    'Name': location.name
            }));
            outputter.table(formatted);
        } else {
            outputter.error('No results or query broken')
        }
    }
}
