/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
import { Command, CommandContext, IFailedCommandOutputter } from "@dolittle/tooling.common.commands";
import { IDependencyResolvers, PromptDependency, argumentUserInputType, IsNotEmpty } from "@dolittle/tooling.common.dependencies";
import { ICanOutputMessages, IBusyIndicator } from "@dolittle/tooling.common.utilities";
import { requireInternet, IConnectionChecker} from "@dolittle/tooling.common.packages";
import { QueryCoordinator } from "@dolittle/queries";
import { AllInstallations } from "../../internal";

const name = 'installations';

const description = `List all created installations`;

export class ListInstallations extends Command {

    constructor(private _edgeAPI: string, private _connectionChecker: IConnectionChecker,
           private _queryCoordinator: QueryCoordinator) {
        super(name, description, false, undefined);
    }
    async onAction(commandContext: CommandContext, dependencyResolvers: IDependencyResolvers, failedCommandOutputter: IFailedCommandOutputter, outputter: ICanOutputMessages, busyIndicator: IBusyIndicator) {
        await requireInternet(this._connectionChecker, busyIndicator);
        QueryCoordinator.apiBaseUrl = this._edgeAPI;
        let commandResult = await this._queryCoordinator.execute(new AllInstallations());
        let results = commandResult.items;
        let formatted: any[] = results.map((location: any) => ({
                'Id': location.id,
                'Name': location.name,
        }));
        outputter.table(formatted);
    }
}
