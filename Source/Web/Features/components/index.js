import { PLATFORM } from 'aurelia-pal';

export function configure(config) {
  config.globalResources(PLATFORM.moduleName('./InlineToolbar/InlineToolbar'));
  config.globalResources(PLATFORM.moduleName('./NavigationList/NavigationList'));
  config.globalResources(PLATFORM.moduleName('./SideBar/SideBar'));
  config.globalResources(PLATFORM.moduleName('./terminal/terminal'));
}
