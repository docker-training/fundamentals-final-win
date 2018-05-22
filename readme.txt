1. Start the database

docker pull microsoft/mssql-server-windows-express
docker run --name=sql -d -p 1434:1433 -e sa_password=P@ssw0rd -e ACCEPT_EULA=Y microsoft/mssql-server-windows-express

2. Run the sql script
docker exec -it <DOCKER_CONTAINER_ID> sqlcmd

docker run -d --name=sql -v sql-data:C:/temp/ microsoft/nanoserver ping -t 127.0.0.1
docker cp init-db.sql sql-data:/init-db.sql

type init-db.sql|docker exec -it sql cmd.exe



2. Seed the database with from the init-db.sql


