/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
import chart_lib from 'chart.js';
import { customElement, bindable, containerless } from 'aurelia-framework';
import * as data_builder from './chart_data_builder';

@customElement('chart')
@containerless()
export class Chart {
  @bindable dataset;
  @bindable chartType = 'line';

  attached() {
    if (this.dataset) {
      let options = data_builder.build_options();
      this.create_chart(this.chartcanvas, this.dataset, options);
    }
  }

  create_chart(chart_element, datasets, options) {
    this._chart = new chart_lib.Chart(chart_element, {
      plugins: [],
      type: this.chartType,
      data: datasets,
      options: options
    });
  }
}
