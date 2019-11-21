/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
import { Plugin } from '@dolittle/tooling.common.plugins';
import { connectionChecker } from '@dolittle/tooling.common.packages';
import { CommandCoordinator } from "@dolittle/commands";
import { QueryCoordinator } from "@dolittle/queries";
import { contexts, loginService } from '@dolittle/tooling.common.login';
import nodeFetch from "node-fetch";
import { CommandGroupsProvider, CommandsProvider, NamespaceProvider,
    EdgeNamespace, AddNodeCommand, DescribeCommandGroup, DescribeInstallation, 
    DescribeNode, DescribeSite, ListCommandGroup, ListInstallations, ListNodes, ListSites, RenameCommandGroup,
    RenameInstallationCommand, RenameNodeCommand, RenameSiteCommand, RegisterCommandGroup, RegisterSiteCommand,
    RegisterNodeCommand, CreateCommandGroup, CreateInstallationCommand, DeleteCommandGroup, DeleteInstallationCommand,
    createAuthenticateCallback, AddCommandGroup
} from "./internal";

(global as any).fetch = nodeFetch;

CommandCoordinator.beforeHandle(createAuthenticateCallback(contexts));
QueryCoordinator.beforeExecute(createAuthenticateCallback(contexts));

let commandCoordinator = new CommandCoordinator();
let queryCoordinator = new QueryCoordinator();

// const edgeApi = 'https://edge.dolittle.studio';
const edgeApi = 'http://localhost:5000/api';

export let commandGroupsProvider = new CommandGroupsProvider([]);

export let commandsProvider = new CommandsProvider([]
);
export let namespaceProvider = new NamespaceProvider([
    // add CreateInstallation as a base level command as it only applies to installations
    new EdgeNamespace([], [
        new AddCommandGroup([
            new AddNodeCommand(edgeApi, loginService, contexts, connectionChecker, commandCoordinator)
        ]),
        new CreateCommandGroup([
            new CreateInstallationCommand(edgeApi, loginService, contexts, connectionChecker, commandCoordinator),
        ]),
        new DeleteCommandGroup([
            new DeleteInstallationCommand(edgeApi, loginService, contexts, connectionChecker, commandCoordinator)
        ]),
        new DescribeCommandGroup([
            new DescribeInstallation(edgeApi, loginService, contexts, connectionChecker, queryCoordinator),
            new DescribeNode(edgeApi, loginService, contexts, connectionChecker, queryCoordinator),
            new DescribeSite(edgeApi, loginService, contexts, connectionChecker, queryCoordinator)
        ]),
        new ListCommandGroup([
            new ListInstallations(edgeApi, loginService, contexts, connectionChecker, queryCoordinator),
            new ListNodes(edgeApi, loginService, contexts, connectionChecker, queryCoordinator),
            new ListSites(edgeApi, loginService, contexts, connectionChecker, queryCoordinator)
        ]),
        new RenameCommandGroup([
            new RenameInstallationCommand(edgeApi, loginService, contexts, connectionChecker, commandCoordinator),
            new RenameNodeCommand(edgeApi, loginService, contexts, connectionChecker, commandCoordinator),
            new RenameSiteCommand(edgeApi, loginService, contexts, connectionChecker, commandCoordinator)
        ]),
        new RegisterCommandGroup([
            new RegisterNodeCommand(edgeApi, loginService, contexts, connectionChecker, commandCoordinator),
            new RegisterSiteCommand(edgeApi, loginService, contexts, connectionChecker, commandCoordinator)
        ])
    ])
]);

export let plugin = new Plugin(commandsProvider, commandGroupsProvider, namespaceProvider);
