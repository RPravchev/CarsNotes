# ASP.NET Core 8.0 MVC - [Car's Notes](https://carsnotes.azurewebsites.net)
## My implementation of a Domain Driven Design architecture, following the SOLID principles:

Core/\
│── Abstractions/ $~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~$ (all custom interfaces)\
│   ├── ICarsService.cs\
│   ├── IRepository.cs\
│   ├── IUnitOfWork.cs\
│── DTOs/ $~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~$ (all DTOs)\
│   ├── CarDto.cs\
│   ├── CarInfoDto.cs\
│── Models/ $~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~$ (all Entities)\
│   ├── Car.cs\
│   ├── Care.cs\
│   ├── Fuel.cs\
│── CarUser.cs $~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~$ (the custom identity user)\
\
Data/\
│── Migrations/ $~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~$ (all migrations)\
│── Repositories/ $~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~$ (all Repositories)\
│   ├── Repository.cs\
│   ├── UnitOfWork.cs\
│── Seed/ $~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~$ (seeding the database)\
│── ApplicationDbContext.cs $~~~~~~~~~~~$ (the db context)\
\
Services/ $~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~$ (all Services)\
│── CarService.cs/\
\
Tests/ $~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~$ (all Tests)\
│── CarServiceTests.cs/	\
\
Web/\
│── Areas/\
│── Controllers/\
│── Mappings/\
│── Models/\
│── Properties/\
│── Views/\
│── wwwroot/\
│── Program.cs\
│── appsettings.json
