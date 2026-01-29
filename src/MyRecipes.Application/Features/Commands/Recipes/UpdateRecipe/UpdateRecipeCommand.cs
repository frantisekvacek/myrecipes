using MyRecipes.Application.Dtos;
using MyRecipes.Application.Features.Commands.Base.BaseUpdate;

namespace MyRecipes.Application.Features.Commands.Recipes.UpdateRecipe;

/// <summary>
/// Update recipe command
/// </summary>
/// <seealso cref="BaseUpdateCommand{RecipeDto, RecipeDto}" />
public sealed class UpdateRecipeCommand : BaseUpdateCommand<RecipeDto, RecipeDto>
{
}
