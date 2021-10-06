: Set up Color for logs.
for /F %%a in ('echo prompt $E ^| cmd') do @set "ESC=%%a"

: Clear screen, in case of previous commands.
@ECHO OFF && CLS
CALL :ColorText "Starting build.bat"

: PSQL must be a environment variable, UserName 'postgres' and Password 'root' needs to be created by default.
CALL :ColorText "Creating DB"
SET PGPASSWORD=root
PSQL -U postgres -f "DB Scripts\CreateDB.sql"

: Create a Tools Manifest & Install DotNet Entity Framework
CALL :ColorText "Creating Manifest to store dotnet EF locally"
DOTNET new tool-manifest --force

CALL :ColorText "Installing dotnet EF locally"
DOTNET tool install dotnet-ef

: Add Migrations & Update Database
CALL :ColorText "Add Migrations"
IF EXIST SolarCoffee.Data\Migrations RMDIR SolarCoffee.Data\Migrations /S /Q
DOTNET dotnet-ef -p SolarCoffee.Data -s SolarCoffee.Web Migrations Add FullMigrations

CALL :ColorText "Update DB"
DOTNET dotnet-ef -p SolarCoffee.Data -s SolarCoffee.Web Database Update

CALL :ColorText "Insert Mock Data"
PSQL -U postgres -f "DB Scripts\Inserts.sql"

: Run BE/FE Solutions.
CALL :ColorText "Running build.bat"
DOTNET run -p SolarCoffee.Web

CALL :ColorText "Finished build.bat"
@ECHO ON
EXIT /B

: Display text with an specific color or a green as default.
:ColorText
    : Red = [31m, Green = [32m, Yellow = [33m, Blue = [34m, Purple = [35m, LightBlue = [36m
    IF "%~2"=="" (SET "COLOR=[33m") ELSE (SET "COLOR=%~2")
    ECHO: && ECHO %ESC%%COLOR% ********** %~1 ********** && ECHO: %ESC%[0m
EXIT /B 0