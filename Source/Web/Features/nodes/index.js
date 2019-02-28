/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
import { observable, PLATFORM } from 'aurelia-framework';
export class index {
  @observable show_terminal = false;
  constructor() { }
  open_terminal() {
    this.show_terminal = true;
  }
  close_terminal() {
    this.show_terminal = false;
  }

  configureRouter(config, router) {
    config.map([
      {
        route: ['','node/:id'],
        name: 'Node',
        moduleId: PLATFORM.moduleName('nodes/NodeDetails')
      },
      {
        route: ['add'],
        name: 'AddNode',
        moduleId: PLATFORM.moduleName('nodes/Add')
      }]);
  }
}
