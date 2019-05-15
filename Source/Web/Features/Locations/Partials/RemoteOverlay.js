/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
import { customElement, containerless, bindable } from 'aurelia-framework';

@customElement('remote-overlay')
@containerless()
export class RemoteOverlay {
  @bindable visible;
  close() {
    this.visible = false;
  }
}