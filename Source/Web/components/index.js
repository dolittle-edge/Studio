import { PLATFORM } from 'aurelia-pal';

export function configure(config) {
  config.globalResources(PLATFORM.moduleName('./side_bar/side_bar'));
}
