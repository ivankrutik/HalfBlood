REM ****************************************************************
REM * File: PublishClickOnceApp.bat *
REM * Author: Doroshenko&Muhamadiev *
REM * Description: This batch file will publish an application as *
REM * a Microsoft ClickOnce deployment. This uses *
REM * Mage.exe command-line utility to create the *
REM * application and deployment manifests. *
REM * Pre-req: .NET Framework 4.5, Windows SDK's *
REM ****************************************************************
@echo off
REM Change these settings, or make them command-line parameters for the batch file.
set version=2
set major=3
set minor=3
set revision=1069
set architecture=x86
set applicationFileDir=c:\temp\Application_Files\v_%version%.%major%.%minor%.%revision%
set configureFileDir=..\configurations
set OutLib=..\OutLib
set appName=Halfblood.Shell
set exeName=%appName%.exe
set manifestName=%exeName%.manifest
set applicationFileName=%appName%.application
set exePath=%applicationFileDir%\%exeName%
set certificate=HalfbloodKey.pfx
set certificatePassword=123
set publishDir=P:\WebServers\Worksite\Halfblood
set publishBase=http://worksite.vz/Halfblood/
set sourceDir=..\%appName%\bin\Release
set publisherName=OAO ���������� �����
set mageExe="C:\Program Files (x86)\Microsoft SDKs\Windows\v8.1A\bin\NETFX 4.5.1 Tools\mage.exe"
set msbuildExe="C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe"
set signExe="C:\Program Files (x86)\Windows Kits\8.1\bin\x64\signtool.exe"
@echo on

 REM Cleanup
 rd /s /q "c:\temp\Application_Files\"
 del /s /q %publishDir%\*
 rmdir /s /q  %publishDir%\Application_Files

REM Build
REM %msbuildExe% /target:Clean;Rebuild /property:configuration=Release;PublisherName="%publisherName%";ProductName="%appName%" "..\PlannedReceiptOrderApp.sln"
    
REM Copy source files to mage directory
 xcopy /E /Y %sourceDir% "%applicationFileDir%\"

xcopy /E /Y %configureFileDir% "%applicationFileDir%\configurations\"
xcopy /E /Y %OutLib% "%applicationFileDir%\OutLib\"
del /q "%applicationFileDir%\*.vshost.*"

 

REM Signing executable
REM %signExe% sign /a %certificate% /p %certificatePassword% "%exePath%"

REM Creating Deployment

%mageExe% -New Application -ToFile "%applicationFileDir%\%manifestName%" -FromDirectory "%applicationFileDir%\." -Name "%appName%" -Version %version%.%major%.%minor%.%revision% -Processor %architecture%
%mageExe% -Sign "%applicationFileDir%\%manifestName%" -CertFile %certificate% -Password %certificatePassword%
%mageExe% -New Deployment -Install false -ToFile "c:\temp\Application_Files\%applicationFileName%" -AppManifest "%applicationFileDir%\%manifestName%" -Name "%appName%" -ProviderURL "%publishBase%%applicationFileName%" -IncludeProviderURL true -Version %version%.%major%.%minor%.%revision% -AppCodeBase "%publishDir%\Application_Files\v_%version%.%major%.%minor%.%revision%\%manifestName%" -Processor %architecture%
%mageExe% -Sign c:\temp\Application_Files\%applicationFileName% -CertFile %certificate% -Password %certificatePassword%

REM Publishing
xcopy /y c:\temp\Application_Files\%applicationFileName% %publishDir%
xcopy /y /s /i "c:\temp\Application_Files" "%publishDir%\Application_Files"
copy /y %applicationFileDir%\publish.htm %publishDir%