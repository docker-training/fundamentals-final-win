# fundamentals-final-win

```
docker system prune -f;

docker-compose up -d;

docker ps;

docker exec -it sqldata cmd.exe /c sqlcmd -S localhost -U SA -P P@ssw0rd -i c:\\temp\\seed.sql

docker exec -it sqldata sqlcmd -S localhost -U SA -P P@ssw0rd -q "USE TestDB; SELECT * FROM Inventory; GO"
```

```
version: '3.1'

services:
 
  sqldata:
    image: microsoft/mssql-server-windows-developer
    container_name: sqldata
    environment:
      - ACCEPT_EULA=Y 
      - sa_password=P@ssw0rd
    volumes:
      - .:C:\temp 
    ports:
      - "1433:1433"
 

```
