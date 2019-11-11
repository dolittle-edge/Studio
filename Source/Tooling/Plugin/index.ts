/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
import {Plugin} from '@dolittle/tooling.common.plugins';
import { connectionChecker } from '@dolittle/tooling.common.packages';
import { CommandGroupsProvider, CommandsProvider, NamespaceProvider,
    EdgeNamespace, GetCommandGroup, GetLocation, GetLocations, ShowCommandGroup, 
    ShowLocations, AddCommandGroup, AddLocationCommand, QueryCoordinator, CommandCoordinator
} from "./internal";
import { AddNodeToLocation } from './Locations/Nodes/AddNodeToLocation';
import { AddNodeCommand } from './edge/add/AddNodeCommand';

// const edgeApi = 'https://edge.dolittle.studio';
const edgeApi = 'http://localhost:5000';
export let commandGroupsProvider = new CommandGroupsProvider([]);

export let commandsProvider = new CommandsProvider([]);
export let namespaceProvider = new NamespaceProvider([
    new EdgeNamespace([], [
        new GetCommandGroup([
            new GetLocation(edgeApi, connectionChecker, new QueryCoordinator()),
            new GetLocations(edgeApi, connectionChecker, new QueryCoordinator())
        ]),
        new ShowCommandGroup([
            new ShowLocations(edgeApi)
        ]),
        new AddCommandGroup([
            new AddLocationCommand(edgeApi, connectionChecker, new CommandCoordinator()),
            new AddNodeCommand(edgeApi, connectionChecker, new CommandCoordinator())
        ])
    ])
]);

export let plugin = new Plugin(commandsProvider, commandGroupsProvider, namespaceProvider);
