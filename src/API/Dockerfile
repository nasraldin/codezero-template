#  <copyright file="Dockerfile" project="API" solution="CodeZeroTemplate">
#      Copyright (c) 2020 Nasr Aldin.  All rights reserved.
#      Licensed under the MIT License, See LICENSE in the project root for license information.
#  </copyright>
#  <author>Nasr Aldin</author>
#  <email>nasr2ldin@gmail.com</email>
#  <github>https://github.com/nasraldin/CodeZero</github>
#  <date>31/05/2020 01:00 AM</date>

#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/API/API.csproj", "src/API/"]
RUN dotnet restore "src/API/API.csproj"
COPY . .
WORKDIR "/src/API"
RUN dotnet build "API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.dll"]
