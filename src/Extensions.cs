using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ContinuousMigrations {
  public static class Extensions {

    private static void ConfigureSettings(this IServiceCollection services) {

      string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

      var config = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .AddJsonFile($"appsettings.{env}.json", optional: true)
          .Build();

      services.Configure<Settings>(s => config.GetSection("ContinuousMigrations"));
    }

    public static IServiceCollection AddContinuousMigrations<T>(this IServiceCollection services)
        where T : DbContext {

      services.ConfigureSettings();

      using (var scope = services.BuildServiceProvider().CreateScope()) {

        var settings = scope.ServiceProvider.GetRequiredService<IOptions<Settings>>();

        if (settings.Value.Enabled)
          using (var context = scope.ServiceProvider.GetRequiredService<T>())
            context.Database.Migrate();

      }

      return services;
    }
  }
}
