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

```

CREATE DATABASE TestDB;
SELECT Name from sys.Databases;
GO

USE TestDB;
CREATE TABLE Inventory (id INT, name NVARCHAR(50), quantity INT);
INSERT INTO Inventory VALUES (1, 'banana', 150); INSERT INTO Inventory VALUES (2, 'orange', 154);
GO

USE TestDB;
SELECT * FROM Inventory;
GO

```
