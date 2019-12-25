/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
import { IContexts } from '@dolittle/tooling.common.login';

export function createAuthenticateCallback(contexts: IContexts) {
    return (options: RequestInit) => {
        let {context} = contexts.current();
        if (context !== undefined) {
            (options.headers as any)['Authorization'] = `Bearer ${context.token}`;
        }
    }
}