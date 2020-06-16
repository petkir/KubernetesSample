#! /usr/bin/env bash
#https://docs.microsoft.com/en-us/azure/aks/kubernetes-walkthrough
#az aks get-credentials --resource-group AKSPetkir --name AKSpetkir

# kubectl create secret docker-register yoursecretname --docker-server=jason.azurecr.io/xxxx/test --docker-username={UserName} --docker-password={Password} --docker-email=team@domain.com


cd k8s
kubectl create namespace ag1
echo -e "Deploying DB Secrets"
kubectl create secret generic mssql --from-literal=SA_PASSWORD="SecureAdminPW10"  -n ag1

echo -e "Deploying Secrets App Insight"
kubectl create -f secrets.yaml -n ag1

echo -e "Deploying  Persistent Volume"
kubectl apply -f PersistentVolume.yaml -n ag1
# echo -e "Deploying  SQL operator HA not support for SQL 2019"
# kubectl apply -f AG1/operator.yaml -n ag1
# kubectl get pod --selector="app=mssql-operator" -n ag1
# echo -e "Deploying  SQL sqlserver"
# kubectl apply -f AG1/sqlserver.yaml -n ag1
# echo -e "Deploying  ag-services"
# kubectl apply -f AG1/ag-services.yaml -n ag1
# kubectl get services -n ag1 -o wide
# echo -e "Deploying  SQL failover"
# kubectl apply -f failover.yaml  — namespace ag1
echo -e "Deploying  SQL 2019"
kubectl apply -f mssql.yaml -n ag1

kubectl get pods -n ag1 -o wide


kubectl get pod -n ag1

kubectl get service -n ag1

kubectl get pod -n ag1


echo -e "Deploy all BackendServices sind auch extern erreichbar"
kubectl apply -f backend.yaml -n ag1

echo -e "Deploy all Front Services"
kubectl apply -f frontend.yaml -n ag1
# helm Hock with user creation would be nice
# sqlcmd -S <External IP Address> -U sa -P "SecureAdminPW10"

echo -e "Watching services..."
kubectl get svc -w

#cleanup
# kubectl delete namespaces ag1

##Single Instance Server
#kubectl create secret generic mssql --from-literal=SA_PASSWORD="MyC0m9l&xP@ssw0rd" 
#kubectl apply -f PersistentVolume.yaml
#kubectl describe pvc mssql-data
#kubectl describe pv
## Single Instnace SQL Server
#kubectl apply -f mssql.yaml
# sqlcmd -S <External IP Address> -U sa -P "MyC0m9l&xP@ssw0rd"
# SQL Availability Group
# https://docs.microsoft.com/en-us/sql/linux/sql-server-linux-availability-group-configure-ha?view=sql-server-ver15



