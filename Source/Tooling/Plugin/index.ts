/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
import { Plugin } from '@dolittle/tooling.common.plugins';
import { connectionChecker } from '@dolittle/tooling.common.packages';
import { CommandGroupsProvider, CommandsProvider, NamespaceProvider,
    EdgeNamespace, AddNodeCommand, DescribeCommandGroup, DescribeInstallation, 
    DescribeNode, DescribeSite, ListCommandGroup, ListInstallations, ListNodes, ListSites, RenameCommandGroup,
    RenameInstallationCommand, RenameNodeCommand, RenameSiteCommand, RegisterCommandGroup, RegisterSiteCommand,
    RegisterNodeCommand, CreateCommandGroup, CreateInstallationCommand, DeleteCommandGroup, DeleteInstallationCommand,

} from "./internal";
import { CommandCoordinator } from "@dolittle/commands";
import { QueryCoordinator } from "@dolittle/queries";
import nodeFetch from "node-fetch";
import { AddCommandGroup } from './edge/add/AddCommandGroup';

(global as any).fetch = nodeFetch;

// const edgeApi = 'https://edge.dolittle.studio';
const edgeApi = 'http://localhost:5000/api';
export let commandGroupsProvider = new CommandGroupsProvider([]);

export let commandsProvider = new CommandsProvider([]
);
export let namespaceProvider = new NamespaceProvider([
    // add CreateInstallation as a base level command as it only applies to installations
    new EdgeNamespace([], [
        new AddCommandGroup([
            new AddNodeCommand(edgeApi, connectionChecker, new CommandCoordinator())
        ]),
        new CreateCommandGroup([
            new CreateInstallationCommand(edgeApi, connectionChecker, new CommandCoordinator()),
        ]),
        new DeleteCommandGroup([
            new DeleteInstallationCommand(edgeApi, connectionChecker, new CommandCoordinator())
        ]),
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
            new RenameInstallationCommand(edgeApi, connectionChecker, new CommandCoordinator()),
            new RenameNodeCommand(edgeApi, connectionChecker, new CommandCoordinator()),
            new RenameSiteCommand(edgeApi, connectionChecker, new CommandCoordinator())
        ]),
        new RegisterCommandGroup([
            new RegisterNodeCommand(edgeApi, connectionChecker, new CommandCoordinator()),
            new RegisterSiteCommand(edgeApi, connectionChecker, new CommandCoordinator())
        ])
    ])
]);

export let plugin = new Plugin(commandsProvider, commandGroupsProvider, namespaceProvider);
