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
  #credentials;

  constructor() {
    /*
    let scheme = document.location.protocol == "https:" ? "wss" : "ws";
    let port = document.location.port ? (":" + document.location.port) : "";
    this._url = `${scheme}://${document.location.hostname}${port}/tty`;
    */
    this._url = 'wss://edge.dolittle.studio/remote-access/';
    this.#credentials = {};

    //this.#start();
  }

  #start(credentials) {
    let self = this;
    this.socket = new WebSocket(this._url);
    this.socket.onopen = (event) => self.#opened(event);
    this.socket.onclose = (event) => self.#closed(event);
    this.socket.onerror = (event) => self.#error(event);
    this.socket.onmessage = (event) => self.#messageReceived(event);
  }

  #opened(event) {
    this.socket.send(JSON.stringify(this.#credentials));
  }

  #closed(event) {
  }

  #error(event) {
  }


  #messageReceived(event) {
    if (event.data instanceof Blob) {
      const reader = new FileReader();
      reader.onloadend = () => {
        this.#terminal.write(reader.result);
      }
      reader.readAsText(event.data);
    } else {
      this.#terminal.write(event.data);
    }
  }

  attached() {
    this.#terminal = new Terminal({
      cursorBlink: true,
      scrollback: 1000,
      tabStopWidth: 8
    });
    this.#terminal.open(this.terminalWindow, true);
    this.#terminal.focus();

    this.#prompt('Host: ', true, (host) => {
      this.#prompt('Username: ', true, (username) => {
        this.#prompt('Password: ', false, (password) => {
          this.#credentials = {
            host: host,
            username: username,
            password: password
          };
          this.#terminal.clear();
          this.#start();

          this.#terminal.on('data', (data) => {
            this.socket.send(data);
          })
        });
      });
    });
  }

  #prompt(text, echo, callback) {
    this.#terminal.write(text);
    let result = '';
    const reader = (data) => {
      result += data;
      if (echo) {
        this.#terminal.write(data);
      }
    };
    const completer = (data, keyData) => {
      if (keyData.keyCode == 13) {
        this.#terminal.off('data', reader);
        this.#terminal.off('key', completer);
        this.#terminal.write('\r\n');
        setImmediate(() => {
          callback(result);
        });
      }
    };
    this.#terminal.on('data', reader);
    this.#terminal.on('key', completer);
  }
}
