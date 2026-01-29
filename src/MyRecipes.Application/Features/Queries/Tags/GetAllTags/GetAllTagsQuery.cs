using MyRecipes.Application.Dtos;
using MyRecipes.Application.Features.Queries.Base.BaseGetAll;

namespace MyRecipes.Application.Features.Queries.Tags.GetAllTags;

/// <summary>
/// Get all tags query
/// </summary>
/// <seealso cref="BaseGetAllQuery{TagDto}" />
public sealed class GetAllTagsQuery : BaseGetAllQuery<TagDto>
{
}
