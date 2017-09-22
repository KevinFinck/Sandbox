ECHO OFF

.\tools\nuget\nuget install Fake -version 4.50.0 -outputdirectory .\tools -noninteractive -source https://www.nuget.org/api/v2/

.\tools\FAKE.4.50.0\tools\FAKE.exe Build.fsx %*

ECHO ON