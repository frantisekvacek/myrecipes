using MyRecipes.Application.Dtos;

namespace MyRecipes.Application.CQRS.Queries.Categories;

/// <summary>
/// Get all categories query
/// </summary>
/// <seealso cref="BaseGetAllQuery{CategoryDto}" />
public sealed class GetAllCategoriesQuery : BaseGetAllQuery<CategoryDto>
{
}
