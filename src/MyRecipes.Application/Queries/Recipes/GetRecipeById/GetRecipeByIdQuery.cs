using MyRecipes.Application.Dtos;
using MyRecipes.Application.Queries.Base.BaseGetById;

namespace MyRecipes.Application.Queries.Recipes.GetRecipeById;

/// <summary>
/// Get recipe by id query
/// </summary>
/// <seealso cref="BaseGetByIdQuery{RecipeDto}" />
public sealed class GetRecipeByIdQuery : BaseGetByIdQuery<RecipeDto>
{
}
