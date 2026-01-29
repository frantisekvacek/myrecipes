using System.Threading.Tasks;

namespace MyRecipes.Application.Features.Base;

/// <summary>
/// Interface for mediator
/// </summary>
public interface IMediator
{
    #region Methods

    /// <summary>
    /// Sends the specified request.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    /// <param name="request">The request.</param>
    /// <returns></returns>
    Task<TResponse> Send<TResponse>(IRequest<TResponse> request);

    #endregion
}
