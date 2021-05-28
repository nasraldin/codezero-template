#  <copyright file="Dockerfile" project="API" solution="CodeZeroTemplate">
#      Copyright (c) 2020 Nasr Aldin.  All rights reserved.
#      Licensed under the MIT License, See LICENSE in the project root for license information.
#  </copyright>
#  <author>Nasr Aldin</author>
#  <email>nasr2ldin@gmail.com</email>
#  <github>https://github.com/nasraldin/CodeZero</github>
#  <date>31/05/2020 01:00 AM</date>

#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS publish
WORKDIR /
COPY ["src/CodeZeroTemplate.API/CodeZeroTemplate.API.csproj", "CodeZeroTemplate.API/"]
COPY ["src/CodeZeroTemplate.Infra/CodeZeroTemplate.Infra.csproj", "CodeZeroTemplate.Infra/"]
COPY ["src/CodeZeroTemplate.Data/CodeZeroTemplate.Data.csproj", "CodeZeroTemplate.Data/"]
COPY ["src/CodeZeroTemplate.Core/CodeZeroTemplate.Core.csproj", "CodeZeroTemplate.Core/"]
COPY ["src/CodeZeroTemplate.Entities/CodeZeroTemplate.Entities.csproj", "CodeZeroTemplate.Entities/"]
RUN dotnet restore "CodeZeroTemplate.API/CodeZeroTemplate.API.csproj" --runtime alpine-x64 --disable-parallel
COPY . .
WORKDIR "/src/CodeZeroTemplate.API"
RUN dotnet publish "CodeZeroTemplate.API.csproj" -c Release -o /app/publish \
  # --no-restore \
  --runtime alpine-x64 \
  --self-contained true \
  /p:PublishTrimmed=true \
  # /p:PublishSingleFile=true
  /p:PublishProtocol=FileSystem

FROM mcr.microsoft.com/dotnet/runtime-deps:5.0-alpine AS final

# RUN adduser --disabled-password \
#   --home /app \
#   --gecos '' dotnetuser && chown -R dotnetuser /app

# upgrade musl to remove potential vulnerability
RUN apk upgrade musl

# USER dotnetuser
WORKDIR /app
EXPOSE 443
COPY --from=publish /app/publish .
COPY /src/CodeZeroTemplate.API/.env.template .env
ENTRYPOINT ["./CodeZeroTemplate.API", "--urls", "https://+:443"]