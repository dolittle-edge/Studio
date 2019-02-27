/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
import { PLATFORM } from 'aurelia-framework';
export class index {
  constructor() {}
  configureRouter(config, router) {
    this.router = router;
    config.title = 'Node';
    config.map([
      { route: ['', 'list'], name: 'List', moduleId: PLATFORM.moduleName('nodes/list') },
      { route: 'remote', name: 'Remote', moduleId: PLATFORM.moduleName('nodes/remote') }
    ]);
  }
}
