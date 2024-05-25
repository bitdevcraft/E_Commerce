This will be use as a webapi template using a clean architecture.

# Requirement

- .Net 8

# Dotnet EF

Installation
`dotnet tool install --global dotnet-ef --version 8.0.2`

Creation of the Migrations
`dotnet ef migrations add InitialCreate -s API -p Persistence`

# Dependency per Module

## API

- Microsoft.AspNetCore.OpenApi
- Microsoft.EntityFrameworkCore.Design
<!-- For ASP.Net Identity -->
- Microsoft.AspNetCore.Authentication.JwtBearer

## Application

- AutoMapper.Extensions.Microsoft.DependencyInjection
- FluentValidation.AspNetCore
- MediatR.Extensions.Microsoft.DependencyInjection

## Persistence

- Microsoft.EntityFrameworkCore.Sqlite

## Domain

<!-- For ASP.Net Identity -->

- Microsoft.AspNetCore.Identity.EntityFrameworkCore

# Test

- Microsoft.EntityFrameworkCore.InMemory
- Moq

## Debugging

Watch the API
`dotnet watch --no-hot-reload`
