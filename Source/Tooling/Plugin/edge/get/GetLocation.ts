/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
import { Command, CommandContext, IFailedCommandOutputter } from "@dolittle/tooling.common.commands";
import { IDependencyResolvers, PromptDependency, argumentUserInputType, IsNotEmpty } from "@dolittle/tooling.common.dependencies";
import { ICanOutputMessages, IBusyIndicator } from "@dolittle/tooling.common.utilities";
import request from 'request-promise-native';
import dateformat from 'dateformat';
import { requireInternet, IConnectionChecker, connectionChecker } from "@dolittle/tooling.common.packages";

const name = 'location';
const description = `Get status from a specific location`;

const nameDependency = new PromptDependency(
    'name',
    'The name of the location',
    [new IsNotEmpty()],
    argumentUserInputType,
    'The name of the location'
);

export class GetLocation extends Command {

    constructor(private _edgeAPI: string, private _connectionChecker: IConnectionChecker) {
        super(name, description, false, undefined, [nameDependency]);
    }
    
    async onAction(commandContext: CommandContext, dependencyResolvers: IDependencyResolvers, failedCommandOutputter: IFailedCommandOutputter, outputter: ICanOutputMessages, busyIndicator: IBusyIndicator) {
        let context = await dependencyResolvers.resolve({}, this.dependencies);
        let name: any = context[nameDependency.name];
        await requireInternet(connectionChecker, busyIndicator);
        let body = await request(`${this._edgeAPI}/api/Locations/${name}`).promise();
        let result = JSON.parse(body);

        result.nodes.forEach((node: any) => {
            let lastUpdated = Date.parse(node.lastUpdated);
            let prettyDateTime = dateformat(lastUpdated, 'yyyy-mm-dd HH:MM:ss');
            outputter.print(`State for node: ${node.name} @ ${prettyDateTime}\n`);

            let states: any[] = [];
            let state: any = {};
            for (let key in node.state) {
                state[key] = `${parseInt(node.state[key])}%`
            }
            states.push(state);

            outputter.table(states);
        });
    }
}
