/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
import { customElement, containerless } from 'aurelia-framework';
import { inject } from 'aurelia-dependency-injection';
import { QueryCoordinator } from '@dolittle/queries';
import { AllNodes } from './AllNodes';

@customElement('nodes-list')
@containerless()
@inject(QueryCoordinator)
export class nodes_list {
  #queryCoordinator;
  nodes = [];

  constructor(queryCoordinator) {
    this.#queryCoordinator = queryCoordinator;
    this.populate();
  }


  async populate() {
    var query = new AllNodes();
    let result = await this.#queryCoordinator.execute(query);
    this.nodes = result.items;
  }


}
