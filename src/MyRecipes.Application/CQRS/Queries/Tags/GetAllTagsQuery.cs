using MyRecipes.Application.CQRS.Queries.Base;
using MyRecipes.Application.Dtos;

namespace MyRecipes.Application.CQRS.Queries.Tags;

/// <summary>
/// Get all tags query
/// </summary>
/// <seealso cref="BaseGetAllQuery{TagDto}" />
public sealed class GetAllTagsQuery : BaseGetAllQuery<TagDto>
{
}
