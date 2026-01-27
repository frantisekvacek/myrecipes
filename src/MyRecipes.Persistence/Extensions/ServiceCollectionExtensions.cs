using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyRecipes.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using MyRecipes.Application.Interfaces.Repositories;
using MyRecipes.Persistence.Repositories;
using MyRecipes.Application;
using System;

namespace MyRecipes.Persistence.Extensions;

/// <summary>
/// Service collection xtension for persitence layer
/// </summary>
public static class ServiceCollectionExtensions
{
    #region Registrations

    /// <summary>
    /// Adds the persistence.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="configuration">The configuration.</param>
    /// <returns></returns>
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        // Register DB Context
        services.AddDbContext<MyRecipeDbContext>(options => options.UseSqlServer(
            configuration.GetConnectionString(Consts.CSqlConnection),
            sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorNumbersToAdd: null);
            }));

        // Register repositories
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IRecipeRepository, RecipeRepository>();

        return services;
    }

    #endregion
}
