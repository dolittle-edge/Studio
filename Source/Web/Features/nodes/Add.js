/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
import { CommandCoordinator } from '@dolittle/commands';
import { Guid } from '@dolittle/core';
import { inject } from 'aurelia-dependency-injection';
import { AddNode } from './AddNode';
import { Router } from 'aurelia-router';

@inject(CommandCoordinator, Router)
export class add {
  #commandCoordinator;
  #router;

  name = '';

  constructor(commandCoordinator, router) {
    this.#commandCoordinator = commandCoordinator;
    this.#router = router;
  }

  async perform() {

    let command = new AddNode();
    command.id = Guid.create();
    command.name = this.name;

    let result = await this.#commandCoordinator.handle(command);
    this.#router.navigateToRoute('Nodes');
    
  }
}
