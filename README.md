# Entity Framework Continuous Migrations

### What is EF Continuous Migrations?

Entity Framework Continuous Migrations is an EF Core extension for conditionally applying pending migrations to a database at runtime using application configuration settings.

### Why would I use it?

You want to ensure the latest EF migrations have been applied during application startup. An example of this would be during an ASP.NET Core application at startup for a given development environment.

### How do I use it?

EF Continuous Migrations is added to an application using the `AddContinuousMigrations<T>` `IServicesCollection` extension method.

The following example shows how this is done for an ASP.NET Core application in the `Startup.ConfigureServices` method for an application using a MySql database.

```csharp
services
    .AddDbContext<BlogContext>(options =>
      options
        .UseMySql(Configuration.GetConnectionString("DefaultConnection"),
              new MySqlServerVersion(new Version(5, 7)),
              x => x.MigrationsAssembly("Web"))
    )
    .AddContinuousMigrations<ApplicationDbContext>()
    .AddControllersWithViews();
```

EF Continuous Migrations is enabled by default and requires no configuration settings. In order to disable migrations from being applied add the following configuration to a your `appsettings.{environment}.json` file:

```json
  "ContinuousMigrations": {
    "Enabled": false
  }
```

A working example can be seen in the Sample application.

### Issue?

If you have any issues please report it here.
