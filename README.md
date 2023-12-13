## ASP.NET Core v8 OpenAPI Template

[![Codacy Badge](https://app.codacy.com/project/badge/Grade/70514795979e4b64b959068a250bf995)](https://www.codacy.com/gh/guildenstern70/AspNetCoreAPI/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=guildenstern70/AspNetCoreAPI&amp;utm_campaign=Badge_Grade)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

A basic Asp.NET Core v8 OpenAPI template. It uses an embedded SQLite database for data persistence.

### Build Docker image

Build

    docker build --platform linux/amd64 -t aspnetcoreapi:1.0 .

Run

    docker run -p 5000:5000 aspnetcoreapi:1.0

### Entity Framework Core setup

Read all about Entity Framework core here:
https://docs.microsoft.com/it-it/ef/core/get-started/overview/first-app?tabs=netcore-cli

    dotnet tool install --global dotnet-ef
    dotnet add package Microsoft.EntityFrameworkCore.Design

If you need to update the Entity Framework core:

    dotnet tool update --global dotnet-ef

### DB Migrations

    cd AspNetCoreAPI
    dotnet ef migrations add InitialCreate
    dotnet ef database update

### Unit Tests

    dotnet test

Please note that the tests rely on a different database which contains only test data. 
The database is for tests is found in the AspNetCoreApi.Test project directory.
To re-create the test database, simply re-run DB migrations and copy DB file ('aspnetcoreapi.db') to the test project directory.
