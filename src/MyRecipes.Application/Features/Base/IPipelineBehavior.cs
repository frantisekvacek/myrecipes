using System;
using System.Threading.Tasks;

namespace MyRecipes.Application.Features.Base;

/// <summary>
/// Interface for pipeline behavior
/// </summary>
/// <typeparam name="TRequest">The type of the request.</typeparam>
/// <typeparam name="TResponse">The type of the response.</typeparam>
public interface IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    #region Methods

    /// <summary>
    /// Handles the specified request.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="next">The next.</param>
    /// <returns></returns>
    Task<TResponse> Handle(TRequest request, Func<Task<TResponse>> next);

    #endregion
}
