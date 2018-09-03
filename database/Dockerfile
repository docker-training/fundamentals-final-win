FROM microsoft/mssql-server-windows-developer

COPY start.ps1 /
COPY init-db.sql /
WORKDIR /
CMD .\start -sa_password $env:sa_password -Verbose