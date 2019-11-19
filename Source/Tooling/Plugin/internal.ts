/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
// Order of exports is important!

export * from './CommandGroupsProvider';
export * from './CommandsProvider';
export * from './NamespaceProvider';

// edge
export * from './edge/EdgeNamespace'
// create an installation
export * from './edge/CreateInstallation';
// delete an installation
export * from './edge/DeleteInstallation';
// move a node
export * from './edge/MoveNode';
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
export * from './edge/rename/RenameInstallation';
export * from './edge/rename/RenameNode';
export * from './edge/rename/RenameSite';
// register
export * from './edge/register/RegisterCommandGroup';
export * from './edge/register/RegisterNode';
export * from './edge/register/RegisterSite';