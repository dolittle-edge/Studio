/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
import { customElement, bindable, containerless, observable } from 'aurelia-framework';

const unnamedSlot = '__au-default-slot-key__';
@customElement('navigation-item')
@containerless()
export class NavigationItem {
  static inject = [Element];
  hasChildren;
  @observable isExpanded = false;
  @bindable routename;

  constructor(element) {
    this.element = element;
  }
  attached() {
    this.$slots = this.element.au.controller.view.slots;
    this.hasChildren = this.$slots[unnamedSlot].children.length > 0;
  }

  toggleExpand() {
    this.isExpanded = !this.isExpanded;
  }
}
