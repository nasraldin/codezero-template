<img height="116" src="https://gitlab.com/nasraldin/codezero/-/raw/dev/devcode.png" />

# CodeZero Template - Clean Architecture, Microservice, DDD
Sample implementation of [CodeZero Framework](https://gitlab.com/nasraldin/codezero) and the **Clean Architecture Principles with .NET Core**.

Central organizing structure, decoupled from frameworks and technology details.

Built by small components that are developed and tested in isolation.

<br/>

## Give a Star! :star:
If you like or are using this project to learn or start your solution, please give it a star. Thanks!

<br/>

> Hit the `WATCH` button to get the latest CodeZero Template updates. 🤷‍♂️

<br/>

> Hit the `FORK` button and show CodeZero Template on your profile. 🌱

<br/>

## Technologies
* [C# 9](https://docs.microsoft.com/en-us/dotnet/csharp)
* [.NET 5](https://dotnet.microsoft.com)
* [EF Core 5](https://docs.microsoft.com/en-us/ef/core)
* [CodeZero Framework](https://gitlab.com/nasraldin/codezero)
* [MariaDB Server](https://mariadb.org)
* [Keycloak](https://www.keycloak.org)
* Testing
  * [xUnit.net](https://xunit.net)
  * [Moq](https://github.com/moq)
  * [Shouldly](https://docs.shouldly.io)
  * [ReportGenerator](https://danielpalme.github.io/ReportGenerator)

<br/>

<!-- screenshot of swagger ui -->
[Swagger Client]
[![Swagger Demo](https://gitlab.com/nasraldin/codezero-template/-/raw/dev/.imgs/Screenshot-2021-05-17-233400.png)]()

<br/>

# Goals

CodeZero Template is implementation of [CodeZero Framework](https://gitlab.com/nasraldin/codezero).

The goal of this project is to provide an open-source a Clean Architecture solution, DDD, SOLID, TDD as well as a containerized microservice as a ready solution to help developers and companies to use in production and focus on other business parts in development.

<br/>

# Overview

<br/>

### ApplicationCore

This will contain all entities, enums, exceptions, interfaces, types and logic specific to the domain layer. No dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example, if the application need to access a notification service, a new interface would be added to application and an implementation would be created within infrastructure.


### Infrastructure

This layer contains all application logic and classes for accessing external resources such as file systems, web services, smtp, and so on. These classes should be based on interfaces defined within the core layer. It is dependent on the core layer, but has no dependencies on any other layer or project.

### Services

This layer is a RestApi application based and ASP .NET Core WebAPI. This layer depends on the Infrastructure layer.

<br/>

# Getting Started

To use this template, there are a few options:

- [Install the Visual Studio Template](https://marketplace.visualstudio.com/items?itemName=CodeZero.Template) and use it within Visual Studio
- Download this Repository
- Install using `dotnet new` (see below)

These are all covered below.

[![Nuget Demo](https://gitlab.com/nasraldin/codezero-template/-/raw/dev/.imgs/Screenshot-2021-05-27-204153.png)]()

## Using the Visual Studio Item Template

After installing the template, you should be able to create a new project in Visual Studio and search for CodeZero Template. You should see the template appear in your list of project templates:

[![Install CodeZero.Template](https://gitlab.com/nasraldin/codezero-template/-/raw/dev/.imgs/Screenshot-2021-05-27-212746.png)]()

[![Install CodeZero.Template](https://gitlab.com/nasraldin/codezero-template/-/raw/dev/.imgs/Screenshot-2021-05-27-212936.png)]()

After choosing this template, provide a project name and finish the project creation wizard. You should be all set.

[![Sloution Explorer](https://gitlab.com/nasraldin/codezero-template/-/raw/dev/.imgs/Screenshot-2021-05-27-211359.png)]()

Note that the template is generally only updated with major updates to the project. The Gitlab/GitHub repository will always have the latest bug fixes and enhancements.

## Using the dotnet CLI template

First, install the template from [NuGet (https://www.nuget.org/packages/CodeZero.Template)](https://www.nuget.org/packages/CodeZero.Template):

```powershell
dotnet new -i CodeZero.Template
```

You should see the template in the list of templates from `dotnet new` after this install successfully. Look for "CodeZero Template" with Short Name of "codezero".

[![Install CodeZero.Template](https://gitlab.com/nasraldin/codezero-template/-/raw/dev/.imgs/Screenshot-2021-05-27-204430.png)]()


```powershell
dotnet new codezero --help
```

[![codezero --help](https://gitlab.com/nasraldin/codezero-template/-/raw/dev/.imgs/Screenshot-2021-05-27-211507.png)]()

Navigate to the directory where you will put the new solution.

Run this command to create the solution structure in a subfolder name `Your.ProjectName`:

```
dotnet new codezero -o Your.ProjectName
```

The `Your.ProjectName` directory and solution file will be created, and inside that will be all of your new solution contents, properly namespaced and ready to run/test!

Example:
[![Create new project](https://gitlab.com/nasraldin/codezero-template/-/raw/dev/.imgs/Screenshot-2021-05-27-204817.png)]()

<br/>

## Build & Run

Build CodeZero docker images, execute the following command:
For Mac/Linux .sh
For Windows .ps1

1- Generate self-signed certificates for local development
```sh
$ cd .cert; ./dotnet-cert.sh && sudo ./hosts.sh add; popd;
```
2- build docker images
in app root path
```sh
$ ./up.sh; popd;
```

[dokcer compose]
[![Swagger Demo](https://gitlab.com/nasraldin/codezero-template/-/raw/dev/.imgs/Screenshot-2021-05-17-233134.png)]()

<br/>

Then the following containers should be running `docker ps`:

| Application 	    | URL                      | Alias                         |
|------------------ | ------------------------ |-------------------------------|
| Portainer 	      | http://localhost:9000    |http://portainer.local:9000    |
| NGINX 	          | http://localhost:5002    |
| CodeZero API 	    | https://localhost:5001   |https://api.dev:5001           |
| SSO Server 	      | http://localhost:8080    |http://sso.local:8080          |
| phpMyAdmin        | http://localhost:8002    |http://phpmyadmin.local:8002   |
| Redis Commander   | http://localhost:8003    |http://redis.local:8003        |
| Camunda Server    | http://localhost:8008    |http://camunda.local:8008      |
| Rabbitmq          | http://localhost:15672   |http://rabbitmq.local:15672    |
| Seq Logs          | http://localhost:5341    |http://seq.local:5341          |

<br/>

Other ports 

| Server       	    | Port                                   |
|------------------ | -------------------------------------- |
| Sftp Server       | 2222                                   |
| Redis Server 	    | 6379                                   |
| Cassandra Server 	| 7000                                   |
| MariaDB Server 	  | 3306                                   |

<br/>

> You can use `nasr` to login for all service or anything need username/password.

<br/>

[portainer]
[![Swagger Demo](https://gitlab.com/nasraldin/codezero-template/-/raw/dev/.imgs/Screenshot-2021-05-17-233327.png)]()

<br/>

If you prefer dotnet commands then start each service individually:

<details>
    <summary>Expand to get the dotnet run steps.</summary>

### Generate Self Signed Certificate

```sh
dotnet dev-certs https --clean
dotnet dev-certs https -ep $env:USERPROFILE\.aspnet\https\aspnetapp.pfx -p CertificatePassword
dotnet dev-certs https --trust
```

### Create and Seed Database

```sh
dotnet tool update --global dotnet-ef
dotnet ef database update --project /src/Data --startup-project /src/API
```

### Running Services

#### API

```sh
dotnet run --project /src/API/API.csproj
```

</details>

<br/>

## Supported Types you can use with MariaDb
- .NET primitives: bool, byte, char, double, float, int, long, sbyte, short, uint, ulong, ushort
- Common types: DateTime, DateTimeOffset, decimal, enum, Guid, string, TimeSpan
- BLOB types: ArraySegment<byte>, byte[], Memory<byte>, ReadOnlyMemory<byte>
- String types: Memory<char>, ReadOnlyMemory<char>, StringBuilder
- Custom MySQL types: MySqlDateTime, MySqlGeometry

## Branch structure

Active development happens on the dev branch. This always contains the latest version. The main branch contains the latest versions of the stable codebase. The prod branch contains a codebase for production release.


## Contributors and Using the GitHub/Gitlab Repository

You can contributor to the project and enhance the solution or add new futuer. just clon and make a PR to dev branch.

To get started based on this repository, you need to get a copy locally. You have three options: fork, clone, or download. Most of the time, you probably just want to download.

You should **download the repository**, unblock the zip file, and extract it to a new folder if you just want to play with the project or you wish to use it as the starting point for an application.

You should **fork this repository** only if you plan on submitting a pull request. Or if you'd like to keep a copy of a snapshot of the repository in your own GitHub account.

You should **clone this repository** if you're one of the contributors and you have commit access to it. Otherwise you probably want one of the other options.

## Support
If you are having problems, please let us know by use the [issue tracker](https://github.com/nasraldin/codezero-template/issues) for that. fill free to support us to request a feature or enhance code or bug report.
* Fix errors.
* Refactoring.
* Build the Front End.
* Submit issues and bugs.

## License

This project is licensed with the [MIT license](LICENSE).
