# ASP.NET Core 8.0 MVC - Car's Notes
## The base of my vision for a Domain Driven Design architecture, following the SOLID principles:

### Core/
### ├── Abstractions/		            (all custom interfacess should be here)
### │   ├── ICarsService.cs
### │   ├── IRepository.cs
### │   ├── IUnitOfWork.cs
### ├── DTOs/                       (all DTOs should be here)
│   ├── CarDto.cs
│   ├── CarInfoDto.cs
├── Models/                     (all Entities should be here)
│   ├── Car.cs
│   ├── Care.cs
│   ├── Fuel.cs
├── CarUser.cs                  (the custom identity user)

Data/
├── Migrations/		              (all migrations should be here)
├── Repositories/               (all Repositories should be here)
│   ├── Repository.cs
│   ├── UnitOfWork.cs
├── Seed/                       (seeding the database)
├── ApplicationDbContext.cs     (the db context)

Services/                       (all Services should be here)
├── CarService.cs/

Tests/                          (all Tests should be here)
├── CarServiceTests.cs/	

Web/
├── Areas/
├── Controllers/
├── Mappings/
├── Models/
├── Properties/
├── Views/
├── wwwroot/
├── Program.cs
├── appsettings.json
