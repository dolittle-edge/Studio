/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
import { Command, CommandContext, IFailedCommandOutputter } from "@dolittle/tooling.common.commands";
import { IDependencyResolvers, PromptDependency, argumentUserInputType, IsNotEmpty } from "@dolittle/tooling.common.dependencies";
import { ICanOutputMessages, IBusyIndicator } from "@dolittle/tooling.common.utilities";
import { requireInternet, IConnectionChecker} from "@dolittle/tooling.common.packages";
import { QueryCoordinator } from "@dolittle/queries";
import { InstallationsOnSite } from "../../internal";

import dateformat from 'dateformat';

const name = 'site';

const description = `Display detailed information of a site`;

const describeSitePromptDependency = new PromptDependency(
    'site name',
    'name of the site',
    [new IsNotEmpty()],
    argumentUserInputType,
    'name of the site'
);

export class DescribeSite extends Command {

    constructor(private _edgeAPI: string, private _connectionChecker: IConnectionChecker,
           private _queryCoordinator: QueryCoordinator) {
        super(name, description, false, undefined, [describeSitePromptDependency]);
    }
    async onAction(commandContext: CommandContext, dependencyResolvers: IDependencyResolvers, failedCommandOutputter: IFailedCommandOutputter, outputter: ICanOutputMessages, busyIndicator: IBusyIndicator) {
        const context = await dependencyResolvers.resolve({}, this.dependencies);
        const siteName: any = context[describeSitePromptDependency.name];
        await requireInternet(this._connectionChecker, busyIndicator);
        QueryCoordinator.apiBaseUrl = this._edgeAPI;
        const commandResult = await this._queryCoordinator.execute(new InstallationsOnSite(siteName));
        const results = commandResult.items;
        const formatted: any[] = results.map((location: any) => ({
                'Id': location.id,
                'Name': location.name,
        }));
        outputter.table(formatted);
    }
}
