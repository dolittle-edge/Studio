/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
import { CommandCoordinator } from '@dolittle/commands';
import { Guid } from '@dolittle/core';
import { inject } from 'aurelia-dependency-injection';
import { AddNode } from './AddNode';

@inject(CommandCoordinator)
export class add {
  #commandCoordinator;

  name = '';

  constructor(commandCoordinator) {
    this.#commandCoordinator = commandCoordinator;
  }


  async perform() {

    let command = new AddNode();
    command.id = Guid.create();
    command.name = this.name;

    let result = await this.#commandCoordinator.handle(command);
  }
}
