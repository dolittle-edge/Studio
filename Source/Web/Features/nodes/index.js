/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
import { observable } from 'aurelia-framework';
export class index {
  @observable show_terminal = false;
  constructor() {}
  open_terminal() {
    this.show_terminal = true;
  }
  close_terminal() {
    this.show_terminal = false;
  }
}
