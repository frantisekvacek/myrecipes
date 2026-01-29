using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MyRecipes.Application.Features.Base;

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

        // Register validation behavior
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        // Register validators
        services.AddValidatorsFromAssemblyContaining<Mediator>();

        return services;
    }

    #endregion
}
