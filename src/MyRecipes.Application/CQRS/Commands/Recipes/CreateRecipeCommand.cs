using MyRecipes.Application.CQRS.Commands.Base;
using MyRecipes.Application.Dtos;

namespace MyRecipes.Application.CQRS.Commands.Recipes;

/// <summary>
/// Create recipe command
/// </summary>
/// <seealso cref="BaseCreateCommand{RecipeDto, RecipeDto}" />
public sealed class CreateRecipeCommand : BaseCreateCommand<RecipeDto, RecipeDto>
{
}
