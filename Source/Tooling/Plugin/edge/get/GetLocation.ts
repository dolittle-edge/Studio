/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
import { Command, CommandContext, IFailedCommandOutputter } from "@dolittle/tooling.common.commands";
import { IDependencyResolvers, PromptDependency, argumentUserInputType, IsNotEmpty } from "@dolittle/tooling.common.dependencies";
import { ICanOutputMessages, IBusyIndicator } from "@dolittle/tooling.common.utilities";
import request from 'request-promise-native';
import dateformat from 'dateformat';
import { requireInternet, IConnectionChecker} from "@dolittle/tooling.common.packages";
import { QueryCoordinator } from "../../internal";
import { LocationById } from "../../internal";

const name = 'location';
const description = `Get status from a specific location`;

const nameDependency = new PromptDependency(
    'LocationId',
    'LocationId',
    [new IsNotEmpty()],
    argumentUserInputType,
    'The id of the location'
);

export class GetLocation extends Command {

    constructor(private _edgeAPI: string, private _connectionChecker: IConnectionChecker,
           private _queryCoordinator: QueryCoordinator) {
        super(name, description, false, undefined, [nameDependency]);
    }
    
    async onAction(commandContext: CommandContext, dependencyResolvers: IDependencyResolvers, failedCommandOutputter: IFailedCommandOutputter, outputter: ICanOutputMessages, busyIndicator: IBusyIndicator) {
        let context = await dependencyResolvers.resolve({}, this.dependencies);
        let locationId: any = context[nameDependency.name];
        await requireInternet(this._connectionChecker, busyIndicator);
        QueryCoordinator.apiBaseUrl = this._edgeAPI;
        let commandResult = await this._queryCoordinator.execute(new LocationById(locationId));
        let results = commandResult.items;
        outputter.print(results);
        let formatted: any[] = results.map((location: any) => ({
                'Id': location.id,
                'Name': location.name,
                'Nodes': `${location.connectedNodes}/${location.totalNodes}`,
                'Last Seen': location.hasBeenSeen ? dateformat(location.lastSeen, 'yyyy-mm-dd HH:MM:ss') : 'never'
        }));
        outputter.table(formatted);
    }
}
