import { PLATFORM } from 'aurelia-pal';

export class App {
  constructor() {}

  configureRouter(config, router) {
    config.options.pushState = true;
    config.map([
      { route: '', name: 'Home', moduleId: PLATFORM.moduleName('home') },
      { route: 'nodes', name: 'Nodes', moduleId: PLATFORM.moduleName('nodes/index') }
    ]);

    this.router = router;
  }
}
