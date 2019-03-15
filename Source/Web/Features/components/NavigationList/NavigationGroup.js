/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
import { customElement, bindable, containerless, observable } from 'aurelia-framework';

@customElement('navigation-group')
@containerless()
export class NavigationGroup {
  @bindable name;
  @observable isExpanded = false;

  constructor() {}
  toggleExpand() {
    this.isExpanded = !this.isExpanded;
  }
}
