import { customElement, containerless, bindable } from 'aurelia-framework';

@customElement('remote-overlay')
@containerless()
export class RemoteOverlay {
  @bindable visible;
  close() {
    this.visible = false;
  }
}
