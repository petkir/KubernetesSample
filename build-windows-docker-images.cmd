
echo -e "Building All Docker Files"
docker build . -f backendapi\Dockerfile -t pekiaks1.azurecr.io/kubtestbackendapi:latest
docker build . -f frontendapi\Dockerfile -t pekiaks1.azurecr.io/kubtestfrontendapi:latest
docker build adminApp\ -f adminApp\Dockerfile -t pekiaks1.azurecr.io/kubtestadminapp:latest
docker build frontend\ -f frontend\Dockerfile -t pekiaks1.azurecr.io/kubtestfrontend:latest

docker build . -f IdentityServer\Dockerfile -t pekiaks1.azurecr.io/kubtestidentityserver:latest
docker build . -f cms\Dockerfile -t pekiaks1.azurecr.io/kubtestcms:latest


echo -e "Logging in to ACR"
az acr login --name pekiaks1
rem  az account clear
rem  az login
echo -e "Pushing backend docker images "


docker push pekiaks1.azurecr.io/kubtestidentityserver:latest
docker push pekiaks1.azurecr.io/kubtestcms:latest

docker push pekiaks1.azurecr.io/kubtestbackendapi:latest
docker push pekiaks1.azurecr.io/kubtestadminapp:latest

docker push pekiaks1.azurecr.io/kubtestfrontendapi:latest
docker push pekiaks1.azurecr.io/kubtestfrontend:latest
echo -e "All windows images pushed to ACR"