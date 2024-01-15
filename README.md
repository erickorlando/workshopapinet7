# Workshop 01 del programa ASP.NET WEB DEVELOPER NET 7

Este proyecto compone todo lo realizado en el primer taller del curso, una API REST desarrollada en C# con una base de datos de SQL Server.

## Pasos para ejecutar el proyecto

Abrir una terminal y ubicarse dentro la carpeta *InstitutoWebApi* del proyecto y escribir lo siguiente

`dotnet ef database update`

Esto permitirá que se cree la base de datos en el servidor LocalDB de SQL Server, teniendo en cuenta que esto viene instalado con Visual Studio.

## Resolucion de Errores

En caso se encuentre un error al ejecutar el comando anterior, se debe instalar el EF Core CLI.

`dotnet tool install dotnet-ef --global --version 7.0.15`


                     _/\__
               ---==/    \\
         ___  ___   |.    \|\
        | __|| __|  |  )   \\\
        | _| | _|   \_/ |  //|\\
        |___||_|       /   \\\/\\

Entity Framework Core .NET Command-line Tools 7.0.15
