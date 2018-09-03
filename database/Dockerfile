FROM microsoft/mssql-server-windows-developer

# make install files accessible
COPY start.ps1 /
COPY init-db.sql /
WORKDIR /

HEALTHCHECK CMD [ "sqlcmd", "-Q", "select 1" ]

CMD .\start -sa_password $env:sa_password -Verbose