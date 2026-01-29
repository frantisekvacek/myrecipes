using System.Threading.Tasks;

namespace MyRecipes.Application.Features.Base;

/// <summary>
/// Interface for request handler
/// </summary>
/// <typeparam name="TRequest">The type of the request.</typeparam>
/// <typeparam name="TResponse">The type of the response.</typeparam>
public interface IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    #region Methods

    /// <summary>
    /// Handles the specified request.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns></returns>
    Task<TResponse> Handle(TRequest request);

    #endregion
}
