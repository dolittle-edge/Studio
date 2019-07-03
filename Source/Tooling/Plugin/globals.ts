/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
import { scriptRunner, templatesBoilerplates } from "@dolittle/tooling.common.boilerplates";
import { folders } from "@dolittle/tooling.common.files";
import { logger } from "@dolittle/tooling.common.logging";
import { dependencyResolvers } from "@dolittle/tooling.common.dependencies";
import { dolittleConfig } from "@dolittle/tooling.common.configurations";
import { DefaultCommandGroupsProvider, DefaultCommandsProvider, NamespaceProvider, EdgeNamespace, GetCommandGroup, GetLocation, GetLocations, ShowCommandGroup, ShowLocations   } from "./index";

const edgeApi = 'https://edge.dolittle.studio';
export let defaultCommandGroupsProvider = new DefaultCommandGroupsProvider([]);

export let defaultCommandsProvider = new DefaultCommandsProvider([]);
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
