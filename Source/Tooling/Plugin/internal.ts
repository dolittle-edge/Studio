/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
// Order of exports is important!

export * from './authenticationCallbacks';

export * from './CommandGroupsProvider';
export * from './CommandsProvider';
export * from './NamespaceProvider';

// get all the proxies
export * from './Installations/AllInstallations';
export * from './Installations/AllNodes';
export * from './Installations/AllSites';
export * from './Installations/CreateInstallation';
export * from './Installations/InstallationsOnSite';
export * from './Installations/RegisterNode';
export * from './Installations/RegisterSite';
export * from './Installations/RenameInstallation';
export * from './Installations/RenameNode';
export * from './Installations/RenameSite';
export * from './Installations/RegisterNodeWithInstallation';
export * from './Installations/NodesWithinInstallation';
export * from './Installations/StatusForAllSites';

// edge
export * from './edge/EdgeNamespace'
// create an installation
export * from './edge/create/CreateCommandGroup';
export * from './edge/create/CreateInstallationCommand';
// delete an installation
export * from './edge/delete/DeleteCommandGroup';
export * from './edge/delete/DeleteInstallationCommand';
// add a node
export * from './edge/add/AddCommandGroup';
export * from './edge/add/AddNodeCommand';
// describe
export * from './edge/describe/DescribeCommandGroup';
export * from './edge/describe/DescribeInstallation';
export * from './edge/describe/DescribeNode';
export * from './edge/describe/DescribeSite';

// list
export * from './edge/list/ListCommandGroup';
export * from './edge/list/ListInstallations';
export * from './edge/list/ListNodes';
export * from './edge/list/ListSites';
// rename
export * from './edge/rename/RenameCommandGroup';
export * from './edge/rename/RenameInstallationCommand';
export * from './edge/rename/RenameNodeCommand';
export * from './edge/rename/RenameSiteCommand';
// register
export * from './edge/register/RegisterCommandGroup';
export * from './edge/register/RegisterNodeCommand';
export * from './edge/register/RegisterSiteCommand';