using MyRecipes.Application.Dtos;
using MyRecipes.Application.Features.Commands.Base.BaseCreate;

namespace MyRecipes.Application.Features.Commands.Recipes.CreateRecipe;

/// <summary>
/// Create recipe command
/// </summary>
/// <seealso cref="BaseCreateCommand{RecipeDto, RecipeDto}" />
public sealed class CreateRecipeCommand : BaseCreateCommand<RecipeDto, RecipeDto>
{
}
