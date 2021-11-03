: Clear screen, in case of previous commands.
@ECHO OFF && CLS

: Setting Variables.
SET PGPASSWORD=root
SET PGUSER="postgres"
SET DBNAME="solardev"

SET WebProject=".\SolarCoffee.Web"
SET DataProject=".\SolarCoffee.Data"
SET MigrationsFolder=".\SolarCoffee.Data\Migrations"

SET CreateScript=".\DB Scripts\CreateDB.sql"
SET InsertsScript=".\DB Scripts\Inserts.sql"

SET BuildBatch=".\build.bat"
SET UtilityBatch=".\utilities.bat"
SET ColorFunction="ColorText"

CALL %UtilityBatch% %ColorFunction% "Starting Script."

: PSQL must be a environment variable, UserName 'postgres' and Password 'root' needs to be created by default.
CALL %UtilityBatch% %ColorFunction% "Creating DB."
PSQL -U %PGUSER% -f %CreateScript%

: Create a Tools Manifest & Install DotNet Entity Framework
CALL %UtilityBatch% %ColorFunction% "Creating Manifest to store dotnet EF locally."
DOTNET new tool-manifest --force

CALL %UtilityBatch% %ColorFunction% "Installing dotnet EF locally."
DOTNET tool install dotnet-ef

: Add Migrations & Update Database
CALL %UtilityBatch% %ColorFunction% "Add Migrations."
IF EXIST %MigrationsFolder% RMDIR %MigrationsFolder% /S /Q
DOTNET dotnet-ef -p %DataProject% -s %WebProject% Migrations Add FullMigrations

CALL %UtilityBatch% %ColorFunction% "Update DB."
DOTNET dotnet-ef -p %DataProject% -s %WebProject% Database Update

CALL %UtilityBatch% %ColorFunction% "Insert Mock Data."
PSQL -U %PGUSER% -d %DBNAME% -f %InsertsScript%

: Run BE/FE Solutions.
CALL %BuildBatch% %WebProject% "Running Build on '%WebProject%'."

CALL %UtilityBatch% %ColorFunction% "Finished Script."
EXIT /B
@ECHO ON