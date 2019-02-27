import { PLATFORM } from 'aurelia-pal';

export function configure(config) {
  config.globalResources(PLATFORM.moduleName('./inline_toolbar/inline_toolbar'));
  config.globalResources(PLATFORM.moduleName('./side_bar/side_bar'));
  config.globalResources(PLATFORM.moduleName('./terminal/terminal'));
}
