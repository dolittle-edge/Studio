/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
import { PLATFORM } from 'aurelia-framework';
export class index {
  configureRouter(config, router) {
    config.map([
      {
        route: '',
        name: 'Node',
        moduleId: PLATFORM.moduleName('nodes/Unselected')
      },
      {
        route: ['node/:id'],
        name: 'Node',
        moduleId: PLATFORM.moduleName('nodes/NodeDetails')
      },
      {
        route: ['add'],
        name: 'AddNode',
        moduleId: PLATFORM.moduleName('nodes/Add')
      }
    ]);
  }
}
