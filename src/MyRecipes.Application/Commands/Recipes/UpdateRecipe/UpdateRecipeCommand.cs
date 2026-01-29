using MyRecipes.Application.Commands.Base.BaseUpdate;
using MyRecipes.Application.Dtos;

namespace MyRecipes.Application.Commands.Recipes.UpdateRecipe;

/// <summary>
/// Update recipe command
/// </summary>
/// <seealso cref="BaseUpdateCommand{RecipeDto, RecipeDto}" />
public sealed class UpdateRecipeCommand : BaseUpdateCommand<RecipeDto, RecipeDto>
{
}
