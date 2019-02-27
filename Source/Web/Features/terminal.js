/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
import { Terminal } from 'xterm';


/**
 * Based on: https://github.com/lovefishs/xterm-example/blob/master/src/main.js
 */
export class terminal {
  #terminal;

  constructor() {
    let scheme = document.location.protocol == "https:" ? "wss" : "ws";
    let port = document.location.port ? (":" + document.location.port) : "";
    this._url = `${scheme}://${document.location.hostname}${port}/tty`;

    this.#start();
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
  }

  #closed(event) {
  }

  #error(event) {
  }


  #messageReceived(event) {
    //JSON.parse(event.data.toString());
    let data = event.data.toString();
    this.#terminal.write(data);
  }

  attached() {
    this.#terminal = new Terminal({
      cursorBlink: true,
      scrollback: 1000,
      tabStopWidth: 8
    });
    this.#terminal.open(this.terminalWindow, true);
    this.#terminal.write('Hello from \x1B[1;3;31mxterm.js\x1B[0m $ ');
    this.#terminal.focus();
    //this.#terminal.prompt();

    this.#terminal.on('key', (data, keyData) => {
      if( keyData.keyCode === 13 ) {
        this.#terminal.write('\n\r');
      }
    });


    this.#terminal.on('data', (data) => {
      //terminal.write(data);
      let message = JSON.stringify({
        data,
        type: 1
      });
      this.socket.send(message);
    });
  }

}
