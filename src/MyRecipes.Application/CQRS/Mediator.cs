using MyRecipes.Application.CQRS.Interfaces;
using System;
using System.Threading.Tasks;

namespace MyRecipes.Application.CQRS;

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
        var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
        dynamic handler = this._serviceProvider.GetService(handlerType);

        return handler == null
            ? throw new InvalidOperationException($"Handler for {request.GetType().Name} not registered.")
            : (TResponse)await handler.Handle((dynamic)request);
    }

    #endregion
}
