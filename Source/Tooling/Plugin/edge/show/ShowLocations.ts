/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
import { Command, CommandContext, IFailedCommandOutputter } from "@dolittle/tooling.common.commands";
import { IDependencyResolvers } from "@dolittle/tooling.common.dependencies";
import { ICanOutputMessages, IBusyIndicator } from "@dolittle/tooling.common.utilities";
import request from 'request-promise-native';
import dateformat from 'dateformat';

const name = 'locations';

const description = `Show all available locations and details`;

export class ShowLocations extends Command {

    constructor(private _edgeAPI: string) {
        super(name, description, false, undefined);
    }
    async onAction(commandContext: CommandContext, dependencyResolvers: IDependencyResolvers, failedCommandOutputter: IFailedCommandOutputter, outputter: ICanOutputMessages, busyIndicator: IBusyIndicator) {
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
