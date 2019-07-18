/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
import { Command } from "@dolittle/tooling.common.commands";
import { IDependencyResolvers, PromptDependency, argumentUserInputType } from "@dolittle/tooling.common.dependencies";
import { ICanOutputMessages, IBusyIndicator, NullMessageOutputter, NullBusyIndicator } from "@dolittle/tooling.common.utilities";
import request from 'request-promise-native';
import dateformat from 'dateformat';
import { requireInternet } from "@dolittle/tooling.common.packages";

const name = 'location';

const description = `Get status from a specific location`;

const nameDependency = new PromptDependency(
    'name',
    'The name of the location',
    argumentUserInputType,
    'The name of the location'
);
let dependencies = [
    nameDependency
];
/**
 * Represents an implementation of {ICommand} for the get location command
 *
 * @export
 * @class GetLocation
 * @extends {Command}
 */
export class GetLocation extends Command {
    /**
     * Instantiates an instance of {GetLocation}.
     * @param {ICommand[]} commands
     */
    constructor(private _edgeAPI: string) {
        super(name, description, false, undefined, dependencies);
    }
    async action(dependencyResolvers: IDependencyResolvers, currentWorkingDirectory: string, coreLanguage: string, commandArguments?: string[], commandOptions?: Map<string, any> , namespace?: string,
                outputter: ICanOutputMessages = new NullMessageOutputter(), busyIndicator: IBusyIndicator = new NullBusyIndicator()) {
        
        let context = await dependencyResolvers.resolve({}, this.getAllDependencies(currentWorkingDirectory, coreLanguage, commandArguments, commandOptions, namespace), 
                            currentWorkingDirectory, coreLanguage, commandArguments, commandOptions )
        let name: any = context[nameDependency.name];
        await requireInternet(busyIndicator);
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
    getAllDependencies(currentWorkingDirectory: string, coreLanguage: string, commandArguments?: string[] , commandOptions?: Map<string, any>, namespace?: string ) {
        return this.dependencies;
    }
}
