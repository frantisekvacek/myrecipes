using MyRecipes.Application.Commands.Base.BaseCreate;
using MyRecipes.Application.Dtos;

namespace MyRecipes.Application.Commands.Recipes.CreateRecipe;

/// <summary>
/// Create recipe command
/// </summary>
/// <seealso cref="BaseCreateCommand{RecipeDto, RecipeDto}" />
public sealed class CreateRecipeCommand : BaseCreateCommand<RecipeDto, RecipeDto>
{
}
