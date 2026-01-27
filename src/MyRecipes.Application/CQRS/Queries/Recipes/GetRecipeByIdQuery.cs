using MyRecipes.Application.CQRS.Queries.Base;
using MyRecipes.Application.Dtos;

namespace MyRecipes.Application.CQRS.Queries.Recipes;

/// <summary>
/// Get recipe by id query
/// </summary>
/// <seealso cref="BaseGetByIdQuery{RecipeDto}" />
public sealed class GetRecipeByIdQuery : BaseGetByIdQuery<RecipeDto>
{
}
