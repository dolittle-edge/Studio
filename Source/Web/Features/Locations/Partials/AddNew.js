/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
import { customElement, containerless, observable } from 'aurelia-framework';

@customElement('add-new')
@containerless()
export class AddNew {
  @observable menuIsVisible = false;
  toggleMenu() {
    this.menuIsVisible = !this.menuIsVisible;
  }
}
