#!/bin/bash -e
set -e
set -x #echo on
docker build -t $_Image:v0.${BUILD_NUMBER} .
docker tag $_Image:v0.${BUILD_NUMBER} $_ContainerReg/$_Image$_BuildType:v0.0.${BUILD_NUMBER} 
docker tag $_Image:v0.${BUILD_NUMBER} $_ContainerReg/$_Image$_BuildType:latest

echo $_DockerPwd | docker login $_ContainerReg -u $_DockerUsr --password-stdin
docker push $_ContainerReg/$_Image$_BuildType:v0.0.${BUILD_NUMBER}
docker push $_ContainerReg/$_Image$_BuildType:latest