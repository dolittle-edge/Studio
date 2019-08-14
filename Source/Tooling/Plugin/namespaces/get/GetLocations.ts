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

const description = `Get status from all locations`;

/**
 * Represents an implementation of {ICommand} for the get locations command
 *
 * @export
 * @class GetLocations
 * @extends {Command}
 */
export class GetLocations extends Command {
    /**
     * Instantiates an instance of {GetLocations}.
     * @param {ICommand[]} commands
     */
    constructor(private _edgeAPI: string) {
        super(name, description, false, undefined);
    }
    async action(dependencyResolvers: IDependencyResolvers, currentWorkingDirectory: string, coreLanguage: string, commandArguments?: string[], commandOptions?: Map<string, any> , namespace?: string,
                outputter: ICanOutputMessages = new NullMessageOutputter(), busyIndicator: IBusyIndicator = new NullBusyIndicator()) {
        
       
    }
    getAllDependencies(currentWorkingDirectory: string, coreLanguage: string, commandArguments?: string[] , commandOptions?: Map<string, any>, namespace?: string ) {
        return this.dependencies;
    }
}
