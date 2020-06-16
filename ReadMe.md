# Kubernetes Sample [![GitHub version](https://badge.fury.io/gh/petkir%2FKubernetesSample.svg)](https://badge.fury.io/gh/petkir%2FKubernetesSample)


## Motivation
A college asks me to make a sample for Kubernetes. A sample takes a while because to find a useful case. So I started to make a checklist that I want to host in the Kubernetes cluster.

I love the MS SQL Server and in azure, I use it normally as Service or as External Service in AKS, but in this is focused to run in different cloud or on-premise environments so I integrated the SQL Server in der Kubernetes cluster


## Kubernetes Cluster Hosts:
* MS SQL Server (no HA)
* WebAPI (dotnet core)
* Indentity Management 
* CMS (dotnet core Razor )
* React Application Hosted in nginx:alpine (FrontEnd)
* Angular Hosted in nginx:alpine (AdminApp)

## Current State
* All Containers work in AKS
* Replica is currently set to 1 for the first tests it's ok

# Getting started
Build Docker Images and push it to Container Registry:
```
build-windows-docker-images.cmd
```
Deploy Kubernestes Cluster with kubectl
```
deploy-all-on-k8s.sh
```


## Upcoming
* Improvements App UI 
* A backend service for internal communication in the cluster only 



## Additional Links
[Deploy a SQL Server container in Kubernetes](https://docs.microsoft.com/en-us/sql/linux/tutorial-sql-server-containers-kubernetes?view=sql-server-ver15)

[High availability for SQL Server containers](https://docs.microsoft.com/en-us/sql/linux/sql-server-linux-container-ha-overview?view=sql-server-ver15)

[SQL Server Replication on Linux](https://docs.microsoft.com/en-us/sql/linux/sql-server-linux-replication?view=sql-server-ver15)

## Disclaimer

**THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.**
