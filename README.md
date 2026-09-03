# programmering-c-sharp
Här kommer jag lägga upp ett antal övningar och genomgångar av grundläggande principer inom c#! 

## Engelska
En sak som ni alla måste vänja er vid är att läsa och skriva allt på engelska. När vi kommer ut på LIA och när vi börjar jobba kommer all dokumentation och all skriven kommunikation ske på engelska. Därför är den här guiden skriven helt på engelska. 

## CLI Cheat sheet

I think it could be handy for some of you to have a sort of CLI (command line interface) cheat sheet dor our dotnet CLI. 

``` Bash 
# To start a new console app
dotnet new console -n name-of-app --use-program-main

# ASP.NET Core Web API
dotnet new webapi -n MyWebApi

# ASP.NET Core Minimal API / Empty Web
dotnet new web -n MyWebApp

# ASP.NET Core MVC application
dotnet new mvc -n MyMvcApp

# Class library (reusable logic)
dotnet new classlib -n MyLibrary

# Unit test projects
dotnet new xunit -n MyTests
dotnet new nunit -n MyTests

# Create a template inside a specific output directory
dotnet new console -n MyConsoleApp -o src/MyConsoleApp

# List all available installed templates
dotnet new list
```
