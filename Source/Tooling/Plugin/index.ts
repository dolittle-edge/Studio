/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
import {Plugin} from '@dolittle/tooling.common.plugins';
import { connectionChecker } from '@dolittle/tooling.common.packages';
import { CommandGroupsProvider, CommandsProvider, NamespaceProvider,
    EdgeNamespace, CreateInstallation, MoveNode, DeleteInstallation, DescribeCommandGroup, DescribeInstallation, 
    DescribeNode, DescribeSite, ListCommandGroup, ListInstallations, ListNodes, ListSites, RenameCommandGroup,
    RenameInstallation, RenameNode, RenameSite, RegisterCommandGroup, RegisterSite, RegisterNode
} from "./internal";
import { CommandCoordinator } from "@dolittle/commands";
import { QueryCoordinator } from "@dolittle/queries";
// import { AddNodeToLocation } from './Locations/Nodes/AddNodeToLocation';
// import { AddNodeCommand } from './edge/add/AddNodeCommand';
import nodeFetch from "node-fetch";
import { Command } from '@dolittle/tooling.common.commands';

(global as any).fetch = nodeFetch;

// const edgeApi = 'https://edge.dolittle.studio';
const edgeApi = 'http://localhost:5000/api';
export let commandGroupsProvider = new CommandGroupsProvider([]);

export let commandsProvider = new CommandsProvider([]
);
export let namespaceProvider = new NamespaceProvider([
    // add CreateInstallation as a base level command as it only applies to installations
    new EdgeNamespace([
            new CreateInstallation(edgeApi, connectionChecker, new CommandCoordinator()),
            new MoveNode(edgeApi, connectionChecker, new CommandCoordinator()),
            new DeleteInstallation(edgeApi, connectionChecker, new CommandCoordinator())
        ], [
        new DescribeCommandGroup([
            new DescribeInstallation(edgeApi, connectionChecker, new QueryCoordinator()),
            new DescribeNode(edgeApi, connectionChecker, new QueryCoordinator()),
            new DescribeSite(edgeApi, connectionChecker, new QueryCoordinator())
        ]),
        new ListCommandGroup([
            new ListInstallations(edgeApi, connectionChecker, new QueryCoordinator()),
            new ListNodes(edgeApi, connectionChecker, new QueryCoordinator()),
            new ListSites(edgeApi, connectionChecker, new QueryCoordinator())
        ]),
        new RenameCommandGroup([
            new RenameInstallation(edgeApi, connectionChecker, new CommandCoordinator()),
            new RenameNode(edgeApi, connectionChecker, new CommandCoordinator()),
            new RenameSite(edgeApi, connectionChecker, new CommandCoordinator())
        ]),
        new RegisterCommandGroup([
            new RegisterNode(edgeApi, connectionChecker, new CommandCoordinator()),
            new RegisterSite(edgeApi, connectionChecker, new CommandCoordinator())
        ])
    ])
]);

export let plugin = new Plugin(commandsProvider, commandGroupsProvider, namespaceProvider);
