using MyRecipes.Application.Dtos;

namespace MyRecipes.Application.CQRS.Queries.Recipes;

/// <summary>
/// Get all recipes query
/// </summary>
/// <seealso cref="BaseGetAllQuery{RecipeDto}" />
public sealed class GetAllRecipesQuery : BaseGetAllQuery<RecipeDto>
{
}
