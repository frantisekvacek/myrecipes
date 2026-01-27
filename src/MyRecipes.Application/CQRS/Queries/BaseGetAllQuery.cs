using MyRecipes.Application.CQRS.Interfaces;
using System.Collections.Generic;

namespace MyRecipes.Application.CQRS.Queries;

/// <summary>
/// Base get all query
/// </summary>
/// <typeparam name="TResponse">The type of the response.</typeparam>
/// <seealso cref="IRequest{IEnumerable{TResponse}}" />
public abstract class BaseGetAllQuery<TResponse> : IRequest<IEnumerable<TResponse>>
{
}
