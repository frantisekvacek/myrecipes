using MyRecipes.Application.Features.Base;
using System.Collections.Generic;

namespace MyRecipes.Application.Features.Queries.Base.BaseGetAll;

/// <summary>
/// Base get all query
/// </summary>
/// <typeparam name="TResponse">The type of the response.</typeparam>
/// <seealso cref="IRequest{IEnumerable{TResponse}}" />
public abstract class BaseGetAllQuery<TResponse> : IRequest<IEnumerable<TResponse>>
{
    #region Properties

    /// <summary>
    /// Gets the search.
    /// </summary>
    /// <value>
    /// The search.
    /// </value>
    public string Search { get; init; }

    #endregion
}
