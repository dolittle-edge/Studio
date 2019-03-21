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
      { route: '', name: 'Home', moduleId: PLATFORM.moduleName('Home') },
      { route: 'applications', name: 'Applications', moduleId: PLATFORM.moduleName('Applications/Index') },
      { route: 'installation', name: 'Installation', moduleId: PLATFORM.moduleName('Installation/Index') },
      { route: 'locations', name: 'Locations', moduleId: PLATFORM.moduleName('Locations/Index') },
      { route: 'locations/add-location', name: 'AddLocation', moduleId: PLATFORM.moduleName('Locations/AddLocation') },
      { route: 'locations/add-node', name: 'AddNode', moduleId: PLATFORM.moduleName('Locations/AddNode') },
      { route: 'setup', name: 'Setup', moduleId: PLATFORM.moduleName('Setup/Index') }
    ]);

    this.router = router;
  }
}
