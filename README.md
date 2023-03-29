# ProTips
## To run Entity Framework db migrations:
if dotnet-ef already installed but not updated run:
```shell
dotnet tool update --global dotnet-ef
```
else
```shell
dotnet tool install --global dotnet-ef
```
    
```shell
dotnet ef --startup-project ./ProTips.API/ --project ./ProTips.Entity/ migrations add CreateTables
```
```shell
dotnet ef --startup-project ./ProTips.API/ --project ./ProTips.Entity/ database update
```

## To revert:
```shell
dotnet ef --startup-project ./ProTips.API/ --project ./ProTips.Entity/ database update 0
```
```shell
dotnet ef --startup-project ./ProTips.API/ --project ./ProTips.Entity/ migrations remove
```

## To run the project:
  - Ensure docker is installed
  - docker-compose up -d --build
