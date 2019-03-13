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
