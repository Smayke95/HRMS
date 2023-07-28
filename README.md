# HRMS
<h3>Human Resource Management Software</h3>
<i>Seminar work - Software development 2 - Faculty of Information Technologies</i> </br>
<i>Made by: Anes Smajic & Irena Vilic</i> </br>

</br>

## About

Human Resource Management Software (HRMS) is an application solution for employee records, department records, position records, employee employment management, vacation records, project and task records, employee communication, reporting, etc. </br>
It uses .NET Api for backend and Flutter for frontend.

</br>

## Architecture

Clean Architecture approach is used. </br>
Please refer to: [Clean Architecture with ASP.NET Core 6](https://www.youtube.com/watch?v=lkmvnjypENw)

### HRMS - Web
Defines all API endpoints, also security and error handling for that endpoints. It uses .NET 7.</br>

[Serilog](https://serilog.net) is used for logging. Logs are saved in folder Logs separated for each day. </br>

[SignalR](https://learn.microsoft.com/en-us/aspnet/signalr/overview/getting-started/introduction-to-signalr) is used for chat between employees. </br>

[Swagger](https://swagger.io/) is used for documenting and testing API endpoints. To open Swagger UI go to /swagger. </br>

[Hangfire](https://www.hangfire.io/) is used as worker and handles _Recurring Jobs_ and _Fire-and-Forget Jobs_. 
Recurring Jobs will execute every night between 00:00 - 04:00, while Fire-and-Forget Jobs will be triggered by some action (ex. sending email). </br>
To open Hangfire Dashboard go to /hangfire.

All Recurring Jobs are defined in `HRMS.Extensions.HangfireExtensions.AddHangfireRecurringJobs()`.

### HRMS.Core - Core
Used to store all business rules and entities. Everything else depends on Core project. </br>


### HRMS.Database - Infrastructure
Defines database (tables, views, procedures) and access to that database. </br>
[Entity Framework Core](https://learn.microsoft.com/en-us/ef/core) is used for database integration.

#### Entity Framework database creation and migration:

	1.) Set HRMS.Database as Startup Project
	2.) In Package Manager Console set Default project to HRMS.Database
	3.) Run commands:

	Add migration: add-migration <migration name>
	Create database: update-database

### HRMS.Desktop - Desktop and Mobile
Uses [Flutter](https://flutter.dev) for desktop and mobile app development. </br>
To generate models run:
```
flutter pub run build_runner build --delete-conflicting-outputs
```

### HRMS.IdentityServer - Web
[IdentityServer4](https://identityserver4.readthedocs.io/en/latest) is used for user authentication.

### HRMS.RabbitMQ - Infrastructure
Integration with [RabbitMQ](https://www.rabbitmq.com/) which is used for notification system.

</br>

## Development

### Requirements
	- Visual Studio 2022
	- Visual Studio Code (with Flutter extension)
	- MS SQL Server 2022 (Database Engine with Full-Text Extractions for Search)
	- Flutter SDK (version 3.0.5 - 4.0.0)
	- Android Studio
	- Docker Desktop

### Docker:
	1.) Run docker run

### ISS Express:
	1.) Open solution HRMS.sln with Visual Studio
	2.) Change connection string inside appsettings.Development.json
	3.) Change Startup item to IIS Express
	4.) Run application with F5

### Flutter:
	1.) Open folder HRMS.Desktop with Visual Studio Code
	2.) Get all packages
	3.) Run application with F5 (Web Api must be running)

</br>

## Testing

Web Api: <a href="https://localhost:44378/">https://localhost:44378/</a> </br>
Swagger: <a href="https://localhost:44378/swagger">https://localhost:44378/swagger</a> </br>
Hangfire: <a href="https://localhost:44378/hangfire">https://localhost:44378/hangfire</a> </br>
RabitMQ: <a href="http://localhost:15672/">http://localhost:15672/</a> </br>

</br>

## Credentials

#### Administrator:
	Email: anes@hrms.com
	Pass:  admin

#### HR manager:
	Email: irena@hrms.com
	Pass:  manager

#### Employee:
	Email: meliha.k@hrms.com
	Pass:  employee

</br>

## Code hygiene

<h4>Visual Studio</h4>

Format code: ```CTRL + K + D``` </br>
Sort usings: ```CTRL + R + G```

<h4>Visual Studio Code</h4>

Format code: ```SHIFT + ALT + F``` </br>
Sort imports: ```SHIFT + ALT + O```

<i>*Use relative import paths.</i>