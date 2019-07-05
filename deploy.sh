#!/bin/bash
docker push dolittle.azurecr.io/edge/core
kubectl patch deployment edge-core --namespace dolittle-edge -p "{\"spec\":{\"template\":{\"metadata\":{\"labels\":{\"date\":\"`date +'%s'`\"}}}}}"