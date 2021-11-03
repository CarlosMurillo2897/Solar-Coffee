: Setting Color for logs.
for /F %%a in ('echo prompt $E ^| cmd') do @set "ESC=%%a"

CALL :%~1 "%~2"
EXIT /B

: Display text with an specific color or a green as default.
:ColorText
    : Red = [31m, Green = [32m, Yellow = [33m, Blue = [34m, Purple = [35m, LightBlue = [36m
    IF "%~2"=="" (SET "COLOR=[33m") ELSE (SET "COLOR=%~2")
    ECHO: && ECHO %ESC%%COLOR% ********** %~1 ********** && ECHO: %ESC%[0m
GOTO :EOF