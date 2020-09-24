#!/bin/bash -e
set -e
set -x #echo on
az login --service-principal -u $_AKSUsr -p $_AKSPwd --tenant $_Tenant
az aks get-credentials --subscription $_SubScription --resource-group $_AKSResourceGroup --name $_AKSClusterName --overwrite-existing
kubectl apply -f $_Image$_PostFix.yaml
kubectl set image deployments/$_Image-deployment $_Image-image=$_ContainerReg/$_Image$_BuildType:v0.0.${BUILD_NUMBER}
kubectl rollout status deployments $_Image-deployment

