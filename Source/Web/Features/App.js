/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
import { PLATFORM } from 'aurelia-pal';

export class App {
  constructor() {}

  configureRouter(config, router) {
    config.options.pushState = true;
    config.map([
      { route: '', name: 'Home', moduleId: PLATFORM.moduleName('Home') }
    ]);

    this.router = router;
  }
}
