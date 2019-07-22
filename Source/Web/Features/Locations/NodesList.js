/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
import { customElement, containerless } from 'aurelia-framework';
import { inject } from 'aurelia-dependency-injection';
import { QueryCoordinator } from '@dolittle/queries';
import { AllNodesForLocation } from './Nodes/AllNodesForLocation';

@customElement('nodes-list')
@containerless()
@inject(QueryCoordinator)
export class NodesList {
  #queryCoordinator;
  nodes = [];

  constructor(queryCoordinator) {
    this.#queryCoordinator = queryCoordinator;
    this.populate();
  }


  async populate() {
    var query = new AllNodesForLocation();
    query.location = '1c8aa985-5350-4b69-aa43-e6c761b97d01';
    let result = await this.#queryCoordinator.execute(query);
    this.nodes = result.items;
  }
}
