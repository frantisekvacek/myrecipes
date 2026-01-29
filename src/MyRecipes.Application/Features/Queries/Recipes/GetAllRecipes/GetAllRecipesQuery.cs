using MyRecipes.Application.Dtos;
using MyRecipes.Application.Features.Queries.Base.BaseGetAll;

namespace MyRecipes.Application.Features.Queries.Recipes.GetAllRecipes;

/// <summary>
/// Get all recipes query
/// </summary>
/// <seealso cref="BaseGetAllQuery{RecipeDto}" />
public sealed class GetAllRecipesQuery : BaseGetAllQuery<RecipeDto>
{
}
