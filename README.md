## EF Core Example
Simple EF Core Example with Migrations

### Requirements
- SQL Server Installed
- EF Core Tools installed: `dotnet tool install --global dotnet-ef`` -- NB! This updates to latest EF Core, you may need to specify version depending on version of EF Core you are using.

### How to run
1. Clone the repo
1. Update `appsettings.json``, specifying connection string to an empty database you have created in SQL Server e.g.
    ```
    {
        ...
        "ConnectionStrings": {
            "DefaultConnection": "Server=(localdb)\\ProjectModels;Database=MyDatabaseName;Trusted_Connection=True;MultipleActiveResultSets=true"
        },
        ...
    }
    ```
1. `dotnet ef database update` to apply the migration
1. Run the project

## Note
- Includes an example of using `Option<T>` as a model property with Configurations, see `UserConfiguration.cs`
- Registers `OptionJsonConverter<T>` in Program.cs to handle serialization/deserialization of `Option<T>` in JSON
- Still need to register `OptionJsonConverter<T>` in `Program.cs` for Swagger