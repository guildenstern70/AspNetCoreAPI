## ASP.NET Core Open API Template

A basic Asp.NET Core v5 OpenAPI template.

#### Build Docker image

Build

    docker build -t guildenstern70/aspnetcoreapi:1.0 .

Run

    docker run -p 5000:5000 guildenstern70/aspnetcoreapi:1.0


#### Entity Framework Core setup

Read all about Entity Framework core here:
https://docs.microsoft.com/it-it/ef/core/get-started/overview/first-app?tabs=netcore-cli

    dotnet tool install --global dotnet-ef
    dotnet add package Microsoft.EntityFrameworkCore.Design

#### DB Migrations

    cd AspNetCoreAPI
    dotnet ef migrations add InitialCreate
    dotnet ef database update
    