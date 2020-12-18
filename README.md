 <img align="left"  height="116" src="https://github.com/nasraldin/CodeZero/blob/main/devcode.png" />
 
 # CodeZero Template - Clean Architecture, Microservice, DDD

<br/>


## Give a Star! :star:
If you like or are using this project to learn or start your solution, please give it a star. Thanks!


## Technologies
* .NET 5
* ASP .NET 5
* Entity Framework 5
* MediatR
* Autofac
* AutoMapper
* FluentValidation
* XUnit, ReportGenerator, Moq & Shouldly
* CodeZero


# Goals
The goal of this project is to provide an open-source IdentityService as a Clean Architecture solution, DDD, SOLID, TDD as well as a containerized microservice as a ready solution to help developers and companies to use in production and focus on other business parts in development.


# Overview

### Core

This will contain all entities, enums, exceptions, interfaces, types and logic specific to the domain layer. No dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example, if the application need to access a notification service, a new interface would be added to application and an implementation would be created within infrastructure.


### Infrastructure

This layer contains all application logic and classes for accessing external resources such as file systems, web services, smtp, and so on. These classes should be based on interfaces defined within the core layer. It is dependent on the core layer, but has no dependencies on any other layer or project.

### API

This layer is a RestApi application based and ASP.NET Core WebAPI 5.0. This layer depends on the Infrastructure layer.


## Branch structure
Active development happens on the dev branch. This always contains the latest version. The main branch contains the latest versions of the stable codebase. The prod branch contains a codebase for production release.


## Contributors and Using the GitHub Repository
You can contributor to the project and enhance the solution or add new futuer. just clon and make a PR to dev branch.

To get started based on this repository, you need to get a copy locally. You have three options: fork, clone, or download. Most of the time, you probably just want to download.

You should **download the repository**, unblock the zip file, and extract it to a new folder if you just want to play with the project or you wish to use it as the starting point for an application.

You should **fork this repository** only if you plan on submitting a pull request. Or if you'd like to keep a copy of a snapshot of the repository in your own GitHub account.

You should **clone this repository** if you're one of the contributors and you have commit access to it. Otherwise you probably want one of the other options.


## Support
If you are having problems, please let us know by use the [issue tracker](https://github.com/nasraldin/codezero-template/issues) for that. fill free to support us to request a feature or enhance code or bug report.


## License

This project is licensed with the [MIT license](LICENSE).
