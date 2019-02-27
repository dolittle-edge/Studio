import { customElement, containerless, bindable } from 'aurelia-framework';

@customElement('remote-overlay')
@containerless()
export class remote_overlay {
  @bindable visible;
  close() {
    this.visible = false;
  }
  visibleChanged(nv) {
    console.log(nv);
  }
}
