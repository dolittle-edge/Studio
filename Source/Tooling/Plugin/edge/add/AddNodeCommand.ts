/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
import { Command, CommandContext, IFailedCommandOutputter } from "@dolittle/tooling.common.commands";
import { IDependencyResolvers, PromptDependency, argumentUserInputType, IsNotEmpty } from "@dolittle/tooling.common.dependencies";
import { ICanOutputMessages, IBusyIndicator } from "@dolittle/tooling.common.utilities";
import { requireInternet, IConnectionChecker} from "@dolittle/tooling.common.packages";
import { CommandCoordinator } from "@dolittle/commands";


const name = 'node';

const description = `Add a node to an installation`;

const nameDependencies = [
        new PromptDependency(
        'node name',
        ' name of the node',
        [new IsNotEmpty()],
        argumentUserInputType,
        'name of the node'
    ),
        new PromptDependency(
        'installation name',
        'name of the installation to be added in to',
        [new IsNotEmpty()],
        argumentUserInputType,
        'name of the installation to be added in to'
    )
];

export class AddNodeCommand extends Command {

    constructor(private _edgeAPI: string, private _connectionChecker: IConnectionChecker,
        private _commandCoordinator : CommandCoordinator) {
        super(name, description, false, undefined, nameDependencies);
    }
    async onAction(commandContext: CommandContext, dependencyResolvers: IDependencyResolvers, failedCommandOutputter: IFailedCommandOutputter, outputter: ICanOutputMessages, busyIndicator: IBusyIndicator) {
        let context = await dependencyResolvers.resolve({}, this.dependencies);
        const nodename: string = context[nameDependencies[0].name];
        const installationName: string = context[nameDependencies[1].name];
        await requireInternet(this._connectionChecker, busyIndicator);
        CommandCoordinator.apiBaseUrl = this._edgeAPI;
/*         let commandResult = await this._commandCoordinator.handle());
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
