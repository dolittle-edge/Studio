/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
import { CommandRequest } from '../internal';
import { Command } from '../internal';
import fetch from 'node-fetch';

const beforeHandleCallbacks: any = [];

/**
 * Represents the coordinator of a {Command}
 */
export class CommandCoordinator {
    static apiBaseUrl: string = '';

    /**
     * Add a callback that gets called before handling a command with the fetch API option object
     * @param {function} callback 
     */
    static beforeHandle(callback: Function) {
        beforeHandleCallbacks.push(callback);
    }

    /**
     * Handle a {Command}
     * @param {Command} command 
     */
    handle(command: Command) {
        let options = {
            credentials: 'same-origin',
            method: 'POST',
            body: JSON.stringify(CommandRequest.createFrom(command)),
            headers: {
                'Content-Type': 'application/json'
            }
        };

        beforeHandleCallbacks.forEach((_: any) => _(options));

        return fetch(`${CommandCoordinator.apiBaseUrl}/api/Dolittle/Commands`, options as any)
            .then(response => response.json());
    }
}