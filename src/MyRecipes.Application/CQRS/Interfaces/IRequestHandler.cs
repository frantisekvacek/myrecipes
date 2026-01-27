using System.Threading.Tasks;

namespace MyRecipes.Application.CQRS.Interfaces;

public interface IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    #region Methods

    Task<TResponse> Handle(TRequest request);

    #endregion
}
