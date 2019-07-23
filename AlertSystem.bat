@echo off 

REM Builds the solution
%WINDIR%\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe .\CaseStudy.sln

REM Runs the console application
".\AlertSystem\bin\Debug\AlertSystem.exe"


REM Checks pass-fail status
IF NOT %ERRORLEVEL% == 0 goto error
echo.
echo PASS
goto end

:error
echo Failed with error code %ERRORLEVEL%.

:end
PAUSE