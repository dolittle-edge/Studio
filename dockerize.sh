#!/bin/bash
docker build -t dolittle/edge-core -f Source/Core/Dockerfile .
pushd
cd ./Source/Web
docker build -t dolittle/edge-web  .
popd