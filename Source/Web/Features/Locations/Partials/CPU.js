/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
import { customElement, bindable, containerless } from 'aurelia-framework';

@customElement('cpu')
@containerless()
export class CPU {
  data = [9, 6, 5, 4, 6, 7, 6, 8, 9, 11, 20, 24, 26, 40, 44, 43, 45, 42, 39, 36, 32, 30, 26, 24];
  dataset = {
    labels: [
      '15:00',
      '15:01',
      '15:02',
      '15:03',
      '15:04',
      '15:05',
      '15:06',
      '15:07',
      '15:08',
      '15:09',
      '15:10',
      '15:11',
      '15:12',
      '15:13',
      '15:14',
      '15:15',
      '15:16',
      '15:17',
      '15:18',
      '15:19',
      '15:20',
      '15:21',
      '15:22',
      '15:23'
    ],
 datasets: [
      {
        label: 'CPU %',
        backgroundColor: 'rgba(51,185,230,0.2)',
        borderColor: 'rgba(51,185,230,1)',
        data: this.data,
        type: 'line',
        pointRadius: 0,
        fill: true,
        lineTension: 0,
        borderWidth: 2
      }
    ]
  };
}
