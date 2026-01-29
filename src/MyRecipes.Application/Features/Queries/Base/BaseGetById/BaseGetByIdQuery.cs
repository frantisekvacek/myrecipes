using MyRecipes.Application.Features.Base;
using System;

namespace MyRecipes.Application.Features.Queries.Base.BaseGetById;

/// <summary>
/// Base get by id query
/// </summary>
/// <typeparam name="TResponse">The type of the response.</typeparam>
/// <seealso cref="IRequest{TResponse}" />
public abstract class BaseGetByIdQuery<TResponse> : IRequest<TResponse>
{
    #region Properties

    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>
    /// The identifier.
    /// </value>
    public Guid Id { get; init; }

    #endregion
}
