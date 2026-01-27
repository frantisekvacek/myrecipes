using MyRecipes.Application.CQRS.Interfaces;
using System;

namespace MyRecipes.Application.CQRS.Queries;

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
    public Guid Id { get; set; }

    #endregion
}
