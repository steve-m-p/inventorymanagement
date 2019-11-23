# Inventory Manangement

## Dependancies

All packages are managed by Nuget Package Manager and will restore on build.  
  
xUnit  
AutoFac  
FluentAssertions

## Usage

Build, Run and Test in Visual Studio 2017. Web Application will launch using IIS Express.  
 Alternatively from Project Root run the following in command ine

```console
dotnet test
dotnet run --project src/InventoryManagement.csproj
```

## Further Improvements
Break out Rules into seperate project  
Seperate Dependancy Injection into seperate Module  
BDD style tests

