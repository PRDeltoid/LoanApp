# LoanApp

Testbed for determining what kind of technologies to use for an SPA Money Lender Application

# Technologies

Currently using ASP.NET Core 2.1 and EntityFramework Core on backend and Reactjs and Nodejs on frontend. MaterialUI used for CSS/styling.

SQL Server 2019 required for database (can be run via Docker image `docker pull mcr.microsoft.com/mssql/server:2019-latest`)

Expected SQL server name is 'sql_server_demo' and can be created via `docker run -d --name sql_server_demo -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=reallyStrongPwd123' -p 1433:1433 microsoft/mssql-server-linux`. Default login information for the above would be: username `sa` password `reallyStrongPwd123`
