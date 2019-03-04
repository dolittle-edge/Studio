/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
import { CommandCoordinator } from '@dolittle/commands';
import { Guid } from '@dolittle/core';
import { inject } from 'aurelia-dependency-injection';
import { AddNodeToLocation } from './AddNodeToLocation';
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

    let command = new AddNodeToLocation();
    command.id = Guid.create();
    command.locationId = '1c8aa985-5350-4b69-aa43-e6c761b97d01';
    command.name = this.name;

    let result = await this.#commandCoordinator.handle(command);
    this.#router.navigateToRoute('Nodes');
    
  }
}
