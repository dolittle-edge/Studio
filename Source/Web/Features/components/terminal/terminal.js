/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
import { containerless } from 'aurelia-framework';
import { Terminal } from 'xterm';

@containerless()
export class terminal {

    constructor() {
        let scheme = document.location.protocol == "https:" ? "wss" : "ws";
        let port = document.location.port ? (":" + document.location.port) : "";
        this._url = `${scheme}://${document.location.hostname}${port}/tty`;

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
        debugger;

    }

    #closed(event) {

    }

    #error(event) {

    }

    #messageReceived(event) {

    }


    attached() {
        let terminal = new Terminal({
            cursorBlink: true,
            scrollback: 1000,
            tabStopWidth: 8
        })
        terminal.open(this.terminal, true);
        terminal.write('Hello from \x1B[1;3;31mxterm.js\x1B[0m $ ');
        terminal.focus();

        terminal.on('data', (data) => {
            terminal.write(data);

        });
    }

}
