/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
import { Command, CommandContext, IFailedCommandOutputter } from "@dolittle/tooling.common.commands";
import { IDependencyResolvers } from "@dolittle/tooling.common.dependencies";
import { ICanOutputMessages, IBusyIndicator } from "@dolittle/tooling.common.utilities";
import { requireInternet, IConnectionChecker } from "@dolittle/tooling.common.packages";
import { QueryCoordinator } from "../../internal";
import { AllLocations } from "../../internal";

const name = 'locations';

const description = `Get status from all locations`;

export class GetLocations extends Command {

    constructor(private _edgeAPI: string, private _connectionChecker: IConnectionChecker, private _queryCoordinator: QueryCoordinator) {
        super(name, description, false, undefined);
    }


    async onAction(commandContext: CommandContext, dependencyResolvers: IDependencyResolvers, failedCommandOutputter: IFailedCommandOutputter, outputter: ICanOutputMessages, busyIndicator: IBusyIndicator) {
        // let context = await dependencyResolvers.resolve({}, this.dependencies);
        // let name: any = context[nameDependency.name];
        await requireInternet(this._connectionChecker, busyIndicator);
        QueryCoordinator.apiBaseUrl = this._edgeAPI;
        let query = await this._queryCoordinator.execute(new AllLocations());
        outputter.print(query);
    }
}
