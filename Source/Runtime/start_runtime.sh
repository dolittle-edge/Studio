#!/bin/bash
docker run -p 50052:50052 -p 50053:50053 -p 8081:8080 -v $PWD/config:/config dolittle/runtime