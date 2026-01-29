using MyRecipes.Application.Dtos;
using MyRecipes.Application.Features.Queries.Base.BaseGetById;

namespace MyRecipes.Application.Features.Queries.Recipes.GetRecipeById;

/// <summary>
/// Get recipe by id query
/// </summary>
/// <seealso cref="BaseGetByIdQuery{RecipeDto}" />
public sealed class GetRecipeByIdQuery : BaseGetByIdQuery<RecipeDto>
{
}
