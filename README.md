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

[Hangfire](https://www.hangfire.io/) is used as worker and handles _Recurring Jobs_ and _Fire-and-Forget Jobs_. </br>
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
Use [Flutter](https://flutter.dev) for desktop and mobile app development. </br>
To generate models run:
```
flutter pub run build_runner build --delete-conflicting-outputs
```

### HRMS.IdentityServer - Web
[IdentityServer4](https://identityserver4.readthedocs.io/en/latest) is used for user authentication.

### HRMS.RabbitMQ - Infrastructure
Integration with [RabbitMQ](https://www.rabbitmq.com/) which is used for notification system. </br>
Use credentials ```admin``` / ```admin``` to access administration module.

</br>

## Development

### Requirements
	- Visual Studio 2022
	- Visual Studio Code (with Flutter extension)
	- MS SQL Server 2022 (Database Engine with Full-Text Extractions for Search)
	- Flutter SDK (version 3.0.5 - 4.0.0)
	- Android Studio
	- Docker Desktop

### ISS Express (Development):
	1.) Open solution HRMS.sln with Visual Studio
	2.) Update appsettings.Development.json in project HRMS
	3.) Update appsettings.Development.json in project HRMS.IdentityServer
	4.) Configure multiple startup projects: HRMS and HRMS.IdentityServer
	5.) Click Start to run application
	6.) Run docker image rabbitmq to enable notifications

### Docker (Production):
	1.) Update .env file in root folder
	2.) Run 'docker compose up'

### Flutter (Development & Production):
	1.) Open folder HRMS.Desktop with Visual Studio Code
	2.) Get all packages
	3.) Update configuration to match development or production urls
	4.) Choose desktop, mobile or web build
	5.) Run application with F5 (HRMS and HRMS.IdentityServer must be running)
	6.) For notifications RabbitMQ must be running

</br>

## Testing

### Development:
[WebApi HTTP](http://localhost:40300/) &emsp; &emsp; &nbsp;[WebApi HTTPS](https://localhost:44300/) </br>
[Swagger HTTP](http://localhost:40300/swagger/index.html) &emsp; &emsp; [Swagger HTTPS](https://localhost:44300/swagger/index.html) </br>
[Hangfire HTTP](http://localhost:40300/hangfire) &emsp; &emsp; [Hangfire HTTPS](https://localhost:44300/hangfire) </br>
[Identity HTTP](http://localhost:40301/) &emsp; &emsp; &nbsp; [Identity HTTPS](https://localhost:44301/) </br>
[RabitMQ HTTP](http://localhost:15672/)&emsp; &emsp; &nbsp;[RabitMQ HTTPS](https://localhost:15672/) </br>

To test HRMS.IdentityServer use: </br>
[https://localhost:44301/login?email=anes@hrms.com&password=admin](https://localhost:44301/login?email=anes@hrms.com&password=admin)

To test mobile application on real device use Dev Tunnels.

### Production:
[WebApi HTTP](http://localhost:50080/) &emsp; &emsp; &nbsp;[WebApi HTTPS](https://localhost:50443/) </br>
[Swagger HTTP](http://localhost:50080/swagger/index.html) &emsp; &emsp; [Swagger HTTPS](https://localhost:50443/swagger/index.html) </br>
[Hangfire HTTP](http://localhost:50080/hangfire) &emsp; &emsp; [Hangfire HTTPS](https://localhost:50443/hangfire) </br>
[Identity HTTP](http://localhost:51080/) &emsp; &emsp; &nbsp; [Identity HTTPS](https://localhost:51443/) </br>
[RabitMQ HTTP](http://localhost:15672/)&emsp; &emsp; &nbsp;[RabitMQ HTTPS](https://localhost:15672/) </br>

To test HRMS.IdentityServer use: </br>
[https://localhost:51443/login?email=anes@hrms.com&password=admin](https://localhost:51443/login?email=anes@hrms.com&password=admin)

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

</br>

## Licence

Project is licensed under the [GNU General Public License v3.0](https://github.com/Smayke95/HRMS/blob/master/LICENSE)