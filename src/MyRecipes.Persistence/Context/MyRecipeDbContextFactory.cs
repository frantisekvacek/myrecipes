using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MyRecipes.Application;
using System;
using System.IO;

namespace MyRecipes.Persistence.Context;

/// <summary>
/// My recipe db context factory
/// </summary>
/// <seealso cref="IDesignTimeDbContextFactory{MyRecipeDbContext}" />
public sealed class MyRecipeDbContextFactory
    : IDesignTimeDbContextFactory<MyRecipeDbContext>
{
    #region Methods

    /// <summary>Creates a new instance of a derived context.</summary>
    /// <param name="args">Arguments provided by the design-time service.</param>
    /// <returns>An instance of <span class="typeparameter">TContext</span>.</returns>
    public MyRecipeDbContext CreateDbContext(string[] args)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile($"appsettings.{environment}.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<MyRecipeDbContext>();

        optionsBuilder.UseSqlServer(configuration.GetConnectionString(Consts.CSqlConnection));

        return new MyRecipeDbContext(optionsBuilder.Options);
    }

    #endregion
}
