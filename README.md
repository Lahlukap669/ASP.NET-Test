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

- .NET 9.0
- Visual Studio 2022 or later

### Building

To build the project, open the `Users.sln` file in Visual Studio and build the solution.

### Running

To run the project, set `Users.API` as the startup project in Visual Studio and start the application.

## API Endpoints

### 1. `GET /api/users`
- **Description**: Retrieves all users.
- **Parameters**: None
- **Headers**: 
  - `X-Api-Key` (string): API Key for authentication.
- **Response**: 
  - `200 OK`: Returns a list of users.
  - `401 Unauthorized`: API Key is missing or invalid.

---

### 2. `GET /api/users/{id}`
- **Description**: Retrieves a user by their ID.
- **Parameters**:
  - `id` (int): The ID of the user.
- **Headers**: 
  - `X-Api-Key` (string): API Key for authentication.
- **Response**: 
  - `200 OK`: Returns the user details.
  - `404 Not Found`: User with the given ID does not exist.
  - `401 Unauthorized`: API Key is missing or invalid.

---

### 3. Delete User
**DELETE** `/api/users/{id}`  
Deletes a user by ID.  
- **Parameters**:
  - `id` (integer, route parameter) - User ID
- **Authorization**: Bearer token required  
- **Responses**:
  - 204 No Content (success)
  - 404 Not Found

---



## Docs

Docs are eccessible via Root connection to the project under endpoint swagger (localhost:7250/swagger) as seen in the picture below. To get access, docs must first be authenticated with APIKey.

![alt text](https://github.com/Lahlukap669/ASP.NET-Test/blob/master/Swagger.png)

## Database
Database is created with EF (EntityFramework) from microsoft. It should already be set once project is cloned or forked (migration exists in files). If it breaks the recommended steps are:
- Navigate to Package Manager Console (StartUpProject:Users.API, DefaultProject:Users.Infrastructure)
- Remove current database if exists: `drop-database`
- Manually delete migration folder (and all migrations)
- Create new migration `add-migration name`
- Sync changes to Database `update-database`

We have seeder files that will populate empty tables User and ApiKey. Now how to get APIKey ... Recommended use of azure data studio (connect to database -> dbname should be UsersDb) and make a costum query like `SELECT * FROM ApiKey`. Copy APIKey and you should be set. CURRENT APIKEY IS SET IN Users.API.Http !!!

## ApiKey
With at least 1 know ApiKey you can generate new ApiKeys, providing name of new client.

# Info
```C#
String AUTHOR = "Luka Lah"; //https://github.com/Lahlukap669
```
