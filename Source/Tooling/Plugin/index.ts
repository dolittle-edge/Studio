/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
import {Plugin} from '@dolittle/tooling.common.plugins';
import { CommandGroupsProvider, CommandsProvider, NamespaceProvider,
    EdgeNamespace, GetCommandGroup, GetLocation, GetLocations, ShowCommandGroup, 
    ShowLocations 
} from "./internal";


const edgeApi = 'https://edge.dolittle.studio';
export let commandGroupsProvider = new CommandGroupsProvider([]);

export let commandsProvider = new CommandsProvider([]);
export let namespaceProvider = new NamespaceProvider([
    new EdgeNamespace([], [
        new GetCommandGroup([
            new GetLocation(edgeApi),
            new GetLocations(edgeApi)
        ]),
        new ShowCommandGroup([
            new ShowLocations(edgeApi)
        ])
    ])
]);

export let plugin = new Plugin(commandsProvider, commandGroupsProvider, namespaceProvider);