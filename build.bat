@ECHO OFF

IF "%~1"=="" (SET "Project=.\SolarCoffee.Web" && CLS) ELSE (SET Project=%~1)
IF "%~2"=="" (SET "StartMessage="Running Build on '%Project%'."") ELSE (SET "StartMessage=%~2")
IF "%~3"=="" (SET "UtilitiesBatch=.\utilities.bat") ELSE (SET "UtilitiesBatch=%~3")
IF "%~4"=="" (SET "ColorFunction=ColorText") ELSE (SET "ColorFunction=%~4")

SET FinishMessage="Finished Build on '%Project%'."

: Run BE/FE Solutions.
CALL %UtilitiesBatch% %ColorFunction% %StartMessage%
DOTNET run -p %Project%
CALL %UtilitiesBatch% %ColorFunction% %FinishMessage%

EXIT /B
@ECHO ON