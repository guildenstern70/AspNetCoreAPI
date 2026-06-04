## ASP.NET Core v10 OpenAPI Template

[![Codacy Badge](https://app.codacy.com/project/badge/Grade/70514795979e4b64b959068a250bf995)](https://www.codacy.com/gh/guildenstern70/AspNetCoreAPI/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=guildenstern70/AspNetCoreAPI&amp;utm_campaign=Badge_Grade)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

A basic Asp.NET Core v10 OpenAPI template. It uses an embedded SQLite database for data persistence.


## Setup

First, you need to create the database. Follow the instructions in the Entity Framework Core setup section below to install the necessary tools and packages. 

Then, run the database migrations to create the SQLite database.

    cd AspNetCoreAPI
    dotnet ef database update

This creates `AspNetCoreAPI/aspnetcoreapi.db`. If you need the test database too, copy it to the test project:

    cp aspnetcoreapi.db ../AspNetCoreAPI.Test/aspnetcoreapi.db


## Build and Run

To build the application run

    dotnet build

To run the application run

    dotnet run


### Build & Run within a container

Build

    docker build -t aspnetcoreapi:1.0 .

Run

    docker run -p 3000:3000 aspnetcoreapi:1.0

### Entity Framework Core setup

Read all about Entity Framework core here:
https://docs.microsoft.com/it-it/ef/core/get-started/overview/first-app?tabs=netcore-cli

    dotnet tool install --global dotnet-ef
    dotnet add package Microsoft.EntityFrameworkCore.Design

If you need to update the Entity Framework core:

    dotnet tool update --global dotnet-ef

### Unit Tests

    dotnet test

Please note that the tests rely on a different database which contains only test data.
The database for tests should be found in the AspNetCoreApi.Test project directory.
