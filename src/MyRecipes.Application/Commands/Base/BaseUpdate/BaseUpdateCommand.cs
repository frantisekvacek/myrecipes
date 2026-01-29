using MyRecipes.Application.Interfaces.Mediators;
using System;

namespace MyRecipes.Application.Commands.Base.BaseUpdate;

/// <summary>
/// Base create/update command
/// </summary>
/// <typeparam name="TDto">The type of the dto.</typeparam>
/// <typeparam name="TResponse">The type of the response.</typeparam>
/// <seealso cref="IRequest{TResponse}" />
public abstract class BaseUpdateCommand<TDto, TResponse> : IRequest<TResponse>
{
    #region Properties

    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>
    /// The identifier.
    /// </value>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the dto.
    /// </summary>
    /// <value>
    /// The dto.
    /// </value>
    public TDto Dto { get; set; }

    #endregion
}