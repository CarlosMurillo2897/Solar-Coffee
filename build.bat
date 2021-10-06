: Setting Color for logs.
for /F %%a in ('echo prompt $E ^| cmd') do @set "ESC=%%a"

: Clear screen, in case of previous commands.
@ECHO OFF && CLS
CALL :ColorText "Starting Build."

: Setting Variables.
SET PGPASSWORD=root
SET PGUSER="postgres"
SET DBNAME="solardev"
SET WebProject=".\SolarCoffee.Web"
SET DataProject=".\SolarCoffee.Data"
SET CreateScript=".\DB Scripts\CreateDB.sql"
SET InsertsScript=".\DB Scripts\Inserts.sql"
SET MigrationsFolder=".\SolarCoffee.Data\Migrations"

: PSQL must be a environment variable, UserName 'postgres' and Password 'root' needs to be created by default.
CALL :ColorText "Creating DB."
PSQL -U %PGUSER% -f %CreateScript%

: Create a Tools Manifest & Install DotNet Entity Framework
CALL :ColorText "Creating Manifest to store dotnet EF locally."
DOTNET new tool-manifest --force

CALL :ColorText "Installing dotnet EF locally."
DOTNET tool install dotnet-ef

: Add Migrations & Update Database
CALL :ColorText "Add Migrations."
IF EXIST %MigrationsFolder% RMDIR %MigrationsFolder% /S /Q
DOTNET dotnet-ef -p %DataProject% -s %WebProject% Migrations Add FullMigrations

CALL :ColorText "Update DB."
DOTNET dotnet-ef -p %DataProject% -s %WebProject% Database Update

CALL :ColorText "Insert Mock Data."
PSQL -U %PGUSER% -d %DBNAME% -f %InsertsScript%

: Run BE/FE Solutions.
CALL :ColorText "Running Build on Web Project."
DOTNET run -p %WebProject%

CALL :ColorText "Finished Build."
@ECHO ON
EXIT /B

: Display text with an specific color or a green as default.
:ColorText
    : Red = [31m, Green = [32m, Yellow = [33m, Blue = [34m, Purple = [35m, LightBlue = [36m
    IF "%~2"=="" (SET "COLOR=[33m") ELSE (SET "COLOR=%~2")
    ECHO: && ECHO %ESC%%COLOR% ********** %~1 ********** && ECHO: %ESC%[0m
EXIT /B 0