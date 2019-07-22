#!/bin/bash
docker tag dolittle/edge-core dolittle/edge-core:poc
docker tag dolittle/edge-web dolittle/edge-web:poc
docker push dolittle/edge-core:poc
docker push dolittle/edge-web:poc