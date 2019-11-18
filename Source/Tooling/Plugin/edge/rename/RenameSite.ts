/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
import { Command, CommandContext, IFailedCommandOutputter } from "@dolittle/tooling.common.commands";
import { IDependencyResolvers, PromptDependency, argumentUserInputType, IsNotEmpty } from "@dolittle/tooling.common.dependencies";
import { ICanOutputMessages, IBusyIndicator } from "@dolittle/tooling.common.utilities";
import { requireInternet, IConnectionChecker} from "@dolittle/tooling.common.packages";
import { CommandCoordinator } from "@dolittle/commands";

import dateformat from 'dateformat';

const name = 'site';

const description = `Display detailed information of a site`;

const nameDependencies = [
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

export class RenameSite extends Command {

    constructor(private _edgeAPI: string, private _connectionChecker: IConnectionChecker,
           private _commandCoordinator : CommandCoordinator) {
        super(name, description, false, undefined, nameDependencies);
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