/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
import { customElement, containerless, bindable } from 'aurelia-framework';

@customElement('applications-list')
@containerless()
export class ApplicationsList {
  @bindable list_item_classname;
  @bindable show_new_box = false;
}
