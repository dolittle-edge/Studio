#!/bin/bash
export VERSION=$(git tag --sort=-version:refname | head -1)
docker build --no-cache -f .//Dockerfile -t dolittle/edge-studio . --build-arg CONFIGURATION="Release"
docker tag dolittle/edge-studio dolittle/edge-studio:$VERSION
docker push dolittle/edge-studio:latest
docker push dolittle/edge-studio:$VERSION