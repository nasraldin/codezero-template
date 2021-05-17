#!/usr/bin/env sh
clear
echo "Build CodeZero docker images"
echo "CodeZero by Nasr Aldin"
echo "nasr2ldin@gmail.com"
echo "----------------------------------------------------------------------------"

if [ `ls -1 .cert/https/api.dev.* 2>/dev/null | wc -l ` -gt 0 ];
then
    echo "Using certificates from $(tput setaf 3)https$(tput sgr0) folder."
else
    echo "ERROR: Failed to find certificates. Check the specific dotnet-cert script for your OS in .cert"
    exit 1
fi
echo "Building Docker images. This may take few minutes..."
docker-compose up -d --build
echo "Build done!"
echo "Run docker ps to check if all containers are up."
echo "Check How to set up a developer certificate for Docker"
echo " https://docs.microsoft.com/en-us/aspnet/core/security/enforcing-ssl"
echo "Browse API url: \n$(tput setaf 3)https://api.dev$(tput sgr0) \n$(tput setaf 3)https://localhost:5001$(tput sgr0)"
xdg-open https://localhost:5001/swagger