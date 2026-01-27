using MyRecipes.Application.Dtos;

namespace MyRecipes.Application.CQRS.Queries.Recipes;

/// <summary>
/// Get rcipe by query
/// </summary>
/// <seealso cref="BaseGetByIdQuery{RecipeDto}" />
public sealed class GetRecipeByIdQuery : BaseGetByIdQuery<RecipeDto>
{
}
