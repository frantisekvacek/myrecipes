using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyRecipes.Application.Features.Base;

/// <summary>
/// Mediator
/// </summary>
/// <seealso cref="IMediator" />
public class Mediator : IMediator
{
    private readonly IServiceProvider _serviceProvider;

    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="Mediator"/> class.
    /// </summary>
    /// <param name="serviceProvider">The service provider.</param>
    public Mediator(IServiceProvider serviceProvider)
    {
        this._serviceProvider = serviceProvider; 
    }

    #endregion

    #region Methods

    /// <summary>
    /// Sends the specified request.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    /// <param name="request">The request.</param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException">Handler for {request.GetType().Name} not registered.</exception>
    public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
    {
        var requestType = request.GetType();

        var handlerType = typeof(IRequestHandler<,>)
            .MakeGenericType(requestType, typeof(TResponse));

        var handler = this._serviceProvider.GetService(handlerType) 
            ?? throw new InvalidOperationException($"Handler for {requestType.Name} not registered.");

        var behaviorType = typeof(IPipelineBehavior<,>)
            .MakeGenericType(requestType, typeof(TResponse));

        var behaviors = this._serviceProvider
            .GetServices(behaviorType)
            .Reverse()
            .ToList();

        /// <summary>
        /// Sends the specified request.
        /// </summary>
        /// <returns></returns>
        Task<TResponse> HandlerDelegate()
        {
            return (Task<TResponse>)handler
                        .GetType()
                        .GetMethod("Handle")!
                        .Invoke(handler, [request])!;
        }

        Func<Task<TResponse>> pipeline = HandlerDelegate;

        foreach (var behavior in behaviors)
        {
            var next = pipeline;
            pipeline = () => ((dynamic)behavior)?.Handle((dynamic)request, next);
        }

        return await pipeline();
    }

    #endregion
}
