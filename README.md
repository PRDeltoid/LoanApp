# LoanApp

Testbed for determining what kind of technologies to use for an SPA Money Lender Application

# Technologies

Mostly tested and written under Windows 10 x64. 

## Backend:
- ASP.NET Core 3.2 as API server
- EntityFramework Core as data layer
- SQL Server 2019 as database

## Frontend:
- NodeJS used as web server
- Reactjs used for webapp
- Material UI used for CSS/styling.

## SQL Server
SQL Server 2019 can be downloaded via Docker using `docker pull mcr.microsoft.com/mssql/server`

A Docker container can be created via PowerShell using the command `docker run -d --name SultanLoansDB -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=reallyStrongPwd123' -p 1433:1433 microsoft/mssql-server-linux`. Using CommandPrompt.exe may cause issues with the single quotes in the above command, so please use PowerShell if possible

Default SQL server name: `SultanLoansDB`
Default user: username `sa` password `reallyStrongPwd123`.

You should have some form of SQL management software (SSMS recommended) to execute SQL scripts to generate the initial database schema (found in CreateDefaultDatabase.sql)
