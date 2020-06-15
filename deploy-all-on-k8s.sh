#! /usr/bin/env bash


if [ "$1" = "" ]; then
    echo -e "Provide a name for the namespace"
    exit 1
fi

cd k8s
kubectl create namespace ag1
echo -e "Deploying DB Secrets"
kubectl create secret generic mssql --from-literal=SA_PASSWORD="SecureAdminPW10" –namespace ag1

echo -e "Deploying Secrets App Insight"
kubectl create -f secrets.yaml -n $1

echo -e "Deploying  Persistent Volume"
kubectl apply -f PersistentVolume.yaml
echo -e "Deploying  SQL operator"
kubectl apply -f AG1/operator.yaml — namespace ag1
kubectl get pod — selector=”app=mssql-operator” -n ag1
echo -e "Deploying  SQL sqlserver"
kubectl apply -f AG1/sqlserver.yaml -n ag1

kubectl get pods –n ag1 -o wide
echo -e "Deploying  ag-services"
kubectl apply -f AG1/ag-services.yaml -n ag1
kubectl get services -n ag1 -o wide

kubectl get pod -n ag1

kubectl get service -n ag1
echo -e "Deploying  SQL failover"
kubectl apply -f failover.yaml  — namespace ag1
kubectl get pod -n ag1


echo -e "Deploy all BackendServices sind auch extern erreichbar"
kubectl create -f backend.yaml -n $1

echo -e "Deploy all Front Services"
kubectl create -f frontend.yaml -n $1
# helm Hock with user creation would be nice
# sqlcmd -S <External IP Address> -U sa -P "SecureAdminPW10"

echo -e "Watching services..."
kubectl get svc -w

##Single Instance Server
#kubectl create secret generic mssql --from-literal=SA_PASSWORD="MyC0m9l&xP@ssw0rd" 
#kubectl apply -f PersistentVolume.yaml

#kubectl describe pvc mssql-data

#kubectl describe pv

## Single Instnace SQL Server
#kubectl apply -f mssql.yaml

#kubectl get pod

#kubectl get services 


# sqlcmd -S <External IP Address> -U sa -P "MyC0m9l&xP@ssw0rd"

# SQL Availability Group
# https://docs.microsoft.com/en-us/sql/linux/sql-server-linux-availability-group-configure-ha?view=sql-server-ver15



