/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
import { customElement, bindable, containerless, observable } from 'aurelia-framework';

@customElement('navigation-item')
@containerless()
export class NavigationItem {
  @bindable routename;
  @bindable iconurl;
  constructor() {}
}
