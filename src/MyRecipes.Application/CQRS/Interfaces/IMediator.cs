using System.Threading.Tasks;

namespace MyRecipes.Application.CQRS.Interfaces;

public interface IMediator
{
    #region Methods

    Task<TResponse> Send<TResponse>(IRequest<TResponse> request);

    #endregion
}
