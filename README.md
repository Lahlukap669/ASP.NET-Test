# ASP.NET-Test

This is a .NET 9.0 web API for managing Users, following the principles of Clean Architecture.

## Project Structure
- `src/Users.API`: The main API project. This is the entry point of the application.
- `src/Users.Application`: Contains the application logic. This layer is responsible for the application's behavior and policies.
- `src/Users.Domain`: Contains enterprise logic and types. This is the core layer of the application.
- `src/Users.Infrastructure`: Contains infrastructure-related code such as database and file system interactions. This layer supports the higher layers.

## Packages and Libraries

This project uses several NuGet packages and libraries to achieve its functionality:

- **Serilog**: This library is used for logging. It provides a flexible and easy-to-use logging API.

- **MediatR**: This library is used to implement the Command Query Responsibility Segregation (CQRS) pattern. In this solution, commands (which change the state of the system) and queries (which read the state) are separated for clarity and ease of development.

- **Entity Framework**: This is an open-source ORM framework for .NET. It enables developers to work with data using objects of domain-specific classes without focusing on the underlying database tables and columns where this data is stored.

- **AutoMapper: Enables easier mapping

- **SwashBuckle: This enables Swagger tools Docs

## Getting Started

### Prerequisites

### Docs
![alt text]([https://github.com/Lahlukap669/ASP.NET-Test/Swagger.png])
