/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
import { customElement, bindable, containerless } from 'aurelia-framework';

@customElement('network')
@containerless()
export class Network {
  data = [
    [40, 16, 44, 70, 40, 69, 32, 34, 20, 33, 60, 64, 78, 77, 66, 75, 76, 64, 78, 65, 67, 56, 32, 44],
    [8, 10, 16, 30, 54, 23, 35, 65, 21, 45, 34, 21, 31, 66, 54, 43, 43, 24, 54, 32, 32, 54, 45, 32]
  ];
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
        label: 'Sent',
        borderColor: 'rgba(51,185,230,1)',
        data: [40, 16, 44, 70, 40, 69, 32, 34, 20, 33, 60, 64, 78, 77, 66, 75, 76, 64, 78, 65, 67, 56, 32, 44],
        type: 'line',
        pointRadius: 0,
        fill: false,
        lineTension: 0.4,
        borderWidth: 2
      },
      {
        label: 'Recieved',
        borderColor: 'rgba(255,207,0,1)',
        data: [8, 10, 16, 30, 54, 23, 35, 65, 21, 45, 34, 21, 31, 66, 54, 43, 43, 24, 54, 32, 32, 54, 45, 32],
        type: 'line',
        pointRadius: 0,
        fill: false,
        lineTension: 0.4,
        borderWidth: 2
      }
    ]
  };
}
