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

const name = 'locations';

const description = `Show all available locations and details`;

/**
 * Represents an implementation of {ICommand} for the get locations command
 *
 * @export
 * @class ShowLocations
 * @extends {Command}
 */
export class ShowLocations extends Command {
    /**
     * Instantiates an instance of {ShowLocations}.
     * @param {ICommand[]} commands
     */
    constructor(private _edgeAPI: string) {
        super(name, description, false, undefined);
    }
    async action(dependencyResolvers: IDependencyResolvers, currentWorkingDirectory: string, coreLanguage: string, commandArguments?: string[], commandOptions?: Map<string, any> , namespace?: string,
                outputter: ICanOutputMessages = new NullMessageOutputter(), busyIndicator: IBusyIndicator = new NullBusyIndicator()) {
        let body = await request(`${this._edgeAPI}/api/Locations/List`).promise();
        let result = JSON.parse(body);
        let formatted: any[] = [];
        result.forEach((location: any) => {
            formatted.push({
                'Id': location.id,
                'Name': location.name,
                'Nodes': `${location.connectedNodes}/${location.totalNodes}`,
                'Last Seen': dateformat(location.lastSeen, 'yyyy-mm-dd HH:MM:ss')
            });
        });
       
        outputter.table(formatted);
    }
    getAllDependencies(currentWorkingDirectory: string, coreLanguage: string, commandArguments?: string[] , commandOptions?: Map<string, any>, namespace?: string ) {
        return this.dependencies;
    }
}
