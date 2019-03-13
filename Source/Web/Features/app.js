import { PLATFORM } from 'aurelia-pal';

export class App {
  constructor() {}

  configureRouter(config, router) {
    config.options.pushState = true;
    config.map([
      { route: '', name: 'Home', moduleId: PLATFORM.moduleName('home') },
      { route: 'applications', name: 'Applications', moduleId: PLATFORM.moduleName('Applications/index') },
      { route: 'installation', name: 'Installation', moduleId: PLATFORM.moduleName('Installation/index') },
      { route: 'locations', name: 'Locations', moduleId: PLATFORM.moduleName('Locations/index') },
      { route: 'setup', name: 'Setup', moduleId: PLATFORM.moduleName('Setup/index') }
    ]);

    this.router = router;
  }
}
