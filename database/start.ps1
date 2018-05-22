param(
[Parameter(Mandatory=$false)]
[string]$sa_password)

# start the service
Write-Verbose "Starting SQL Server"
Start-Service MSSQLSERVER

# set SA credentials
if($sa_password -ne "_")
{
    Write-Verbose "Changing SA login credentials"
    $sqlcmd = "ALTER LOGIN sa with password=" +"'" + $sa_password + "'" + ";ALTER LOGIN sa ENABLE;"
    & sqlcmd -Q $sqlcmd
}

# seed the database
Write-Verbose "Seeding database."
& sqlcmd -S localhost -U SA -P $sa_password -i c:\init-db.sql

$lastCheck = (Get-Date).AddSeconds(-2) 

while ($true) 
{ 
    Get-EventLog -LogName Application -Source "MSSQL*" -After $lastCheck | Select-Object TimeGenerated, EntryType, Message	 
    $lastCheck = Get-Date 
    Start-Sleep -Seconds 2 
}