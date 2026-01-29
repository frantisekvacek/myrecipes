using MyRecipes.Application.Dtos;
using MyRecipes.Application.Queries.Base.BaseGetAll;

namespace MyRecipes.Application.Queries.Tags.GetAllTags;

/// <summary>
/// Get all tags query
/// </summary>
/// <seealso cref="BaseGetAllQuery{TagDto}" />
public sealed class GetAllTagsQuery : BaseGetAllQuery<TagDto>
{
}
