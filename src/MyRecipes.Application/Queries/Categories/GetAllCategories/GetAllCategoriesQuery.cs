using MyRecipes.Application.Dtos;
using MyRecipes.Application.Queries.Base.BaseGetAll;

namespace MyRecipes.Application.Queries.Categories.GetAllCategories;

/// <summary>
/// Get all categories query
/// </summary>
/// <seealso cref="BaseGetAllQuery{CategoryDto}" />
public sealed class GetAllCategoriesQuery : BaseGetAllQuery<CategoryDto>
{
}
