using Microsoft.Extensions.DependencyInjection;
using MyRecipes.Application.Features.Base;
using MyRecipes.Application.Mediators;

namespace MyRecipes.Application.Extensions;

/// <summary>
/// Service collection extension for application layer
/// </summary>
public static class ServiceCollectionExtensions
{
    #region Registrations

    /// <summary>
    /// Adds the application.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <returns></returns>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Register mediator
        services.AddScoped<IMediator, Mediator>();

        // Dynamic handlers registration
        services.Scan(scan => scan
                .FromAssemblyOf<Mediator>()
                .AddClasses(classes => classes.AssignableTo(typeof(IRequestHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
        );

        return services;
    }

    #endregion
}
