using MyRecipes.Application.Dtos;

namespace MyRecipes.Application.CQRS.Commands.Recipes;

/// <summary>
/// Update recipe command
/// </summary>
/// <seealso cref="BaseUpdateCommand{RecipeDto, RecipeDto}" />
public sealed class UpdateRecipeCommand : BaseUpdateCommand<RecipeDto, RecipeDto>
{
}
