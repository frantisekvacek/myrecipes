using MyRecipes.Application.Dtos;
using MyRecipes.Application.Queries.Base.BaseGetAll;

namespace MyRecipes.Application.Queries.Recipes.GetAllRecipes;

/// <summary>
/// Get all recipes query
/// </summary>
/// <seealso cref="BaseGetAllQuery{RecipeDto}" />
public sealed class GetAllRecipesQuery : BaseGetAllQuery<RecipeDto>
{
}
