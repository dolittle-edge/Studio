/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
import { customElement, containerless, bindable } from 'aurelia-framework';

@customElement('side-bar')
@containerless()
export class SideBar {
  @bindable expanded = false;
  @bindable hide_trigger;
  @bindable is_subnavigation;
  constructor() {}

  toggleSideBar() {
    this.expanded = !this.expanded;
  }
}
