/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
export function build_options() {
  return {
    title: {
      display: false
    },
    responsive: true,
    maintainAspectRatio: false,
    legend: {
      display: true,
      position: 'bottom',
      labels: {
        fontColor: 'rgba(255,255,255,0.6)'
      }
    },
    layout: {
      padding: {
        left: 5,
        right: 5,
        top: 5,
        bottom: 5
      }
    },
    hover: {
      intersect: false
    },
    elements: {
      line: {
        tension: 0
      }
    }
  };
}
export function time_options() {
  return {
    scales: {
      xAxes: [
        {
          id: 'time',
          type: 'time',
          distribution: 'series',
          time: {
            min: 0,
            max: 10,
            unit: 'minute',
            source: 'data',
            autoSkip: true
          }
        }
      ],
      yAxes: [
        {
          scaleLabel: {
            display: true,
            labelString: '%',
            fontColor: 'rgba(255,255,255,0.6)'
          }
        }
      ]
    },
    tooltips: {
      intersect: false,
      mode: 'index'
    }
  };
}
