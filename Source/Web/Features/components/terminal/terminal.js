/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
import { containerless } from 'aurelia-framework';
import { Terminal } from 'xterm';

/**
 * Based on: https://github.com/lovefishs/xterm-example/blob/master/src/main.js
 */
@containerless()
export class terminal {
  #terminal;

  constructor() {
    /*
    let scheme = document.location.protocol == "https:" ? "wss" : "ws";
    let port = document.location.port ? (":" + document.location.port) : "";
    this._url = `${scheme}://${document.location.hostname}${port}/tty`;
    */
    this._url = 'wss://edge.dolittle.studio/remote-access/';
    
    //this.#start();
  }

  #start() {
    let self = this;
    this.socket = new WebSocket(this._url);
    this.socket.onopen = (event) => self.#opened(event);
    this.socket.onclose = (event) => self.#closed(event);
    this.socket.onerror = (event) => self.#error(event);
    this.socket.onmessage = (event) => self.#messageReceived(event);
  }

  #opened(event) {
    this.socket.send(JSON.stringify({
      host: '',
      username: '',
      password: ''
    }));
  }

  #closed(event) {
  }

  #error(event) {
  }


  #messageReceived(event) {
    const reader = new FileReader();
    reader.onloadend = () => {
      this.#terminal.write(reader.result);
    }
    reader.readAsText(event.data);
  }

  attached() {
    this.#terminal = new Terminal({
      cursorBlink: true,
      scrollback: 1000,
      tabStopWidth: 8
    });
    this.#terminal.open(this.terminalWindow, true);
    this.#terminal.focus();

    this.#start();

    this.#terminal.on('data', (data) => {
      this.socket.send(data);
    });
  }
}
