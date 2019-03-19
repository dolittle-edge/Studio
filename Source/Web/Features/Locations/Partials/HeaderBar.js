/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
import { customElement, containerless, observable } from 'aurelia-framework';

@customElement('header-bar')
@containerless()
export class HeaderBar {
  @observable show_terminal = false;
  open_terminal() {
    this.show_terminal = true;
  }
}
