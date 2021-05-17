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
COPY ["src/API/API.csproj", "API/"]
COPY ["src/Data/Data.csproj", "Data/"]
COPY ["src/Infra/Infra.csproj", "Infra/"]
COPY ["src/Core/Core.csproj", "Core/"]
COPY ["src/Entities/Entities.csproj", "Entities/"]
RUN dotnet restore "API/API.csproj" --runtime alpine-x64 --disable-parallel
COPY . .
WORKDIR "/src/API"
RUN dotnet publish "API.csproj" -c Release -o /app/publish \
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
COPY /src/API/.env.template .env
ENTRYPOINT ["./API", "--urls", "https://+:443"]