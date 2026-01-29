using MyRecipes.Application.Features.Base;

namespace MyRecipes.Application.Features.Commands.Base.BaseCreate;

/// <summary>
/// Base create/update command
/// </summary>
/// <typeparam name="TDto">The type of the dto.</typeparam>
/// <typeparam name="TResponse">The type of the response.</typeparam>
/// <seealso cref="IRequest{TResponse}" />
public abstract class BaseCreateCommand<TDto, TResponse> : IRequest<TResponse>
{
    #region Properties

    /// <summary>
    /// Gets or sets the dto.
    /// </summary>
    /// <value>
    /// The dto.
    /// </value>
    public TDto Dto { get; set; }

    #endregion
}