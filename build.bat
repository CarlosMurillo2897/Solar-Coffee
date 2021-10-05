: Clear screen, in case of previous commands.
CLS

: PSQL must be a environment variable.
: UserName 'postgres' and Password 'root' needs to be created by default.
SET PGPASSWORD=root
PSQL -U postgres -f "script.sql"

: Create a Tools Manifest & Install DotNet Entity Framework
DOTNET new tool-manifest --force
DOTNET tool install dotnet-ef

: Add Migrations & Update Database
CD SolarCoffee.Data

IF EXIST Migrations RMDIR Migrations /S /Q
DOTNET dotnet-ef -s ..\SolarCoffee.Web Migrations Add FullMigrations
DOTNET dotnet-ef -s ..\SolarCoffee.Web Database Update

CD ..