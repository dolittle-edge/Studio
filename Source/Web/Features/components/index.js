/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
import { PLATFORM } from 'aurelia-pal';

export function configure(config) {
  config.globalResources(PLATFORM.moduleName('./AdminList/AdminList'));
  config.globalResources(PLATFORM.moduleName('./Chart/Chart'));
  config.globalResources(PLATFORM.moduleName('./InlineToolbar/InlineToolbar'));
  config.globalResources(PLATFORM.moduleName('./NavigationGroup/NavigationGroup'));
  config.globalResources(PLATFORM.moduleName('./NavigationItem/NavigationItem'));
  config.globalResources(PLATFORM.moduleName('./NavigationList/NavigationList'));
  config.globalResources(PLATFORM.moduleName('./SideBar/SideBar'));
  config.globalResources(PLATFORM.moduleName('./terminal/terminal'));
}
