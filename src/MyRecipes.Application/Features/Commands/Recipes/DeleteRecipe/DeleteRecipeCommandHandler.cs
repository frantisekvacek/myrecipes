using Microsoft.Extensions.Logging;
using MyRecipes.Application.Dtos;
using MyRecipes.Application.Features.Commands.Base.BaseDelete;
using MyRecipes.Application.Interfaces.Repositories;
using MyRecipes.Domain.Entities;
using System;

namespace MyRecipes.Application.Features.Commands.Recipes.DeleteRecipe;

/// <summary>
/// Delete recipe command handler
/// </summary>
/// <seealso cref="BaseDeleteCommandHandler{DeleteRecipeCommand, Recipe, RecipeDto}" />
public sealed class DeleteRecipeCommandHandler : BaseDeleteCommandHandler<DeleteRecipeCommand, Recipe, RecipeDto>
{
    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteRecipeCommandHandler" /> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="recipeRepository">The category repository.</param>
    /// <exception cref="ArgumentNullException">categoryRepository</exception>
    public DeleteRecipeCommandHandler(
        ILogger<DeleteRecipeCommandHandler> logger,
        IRecipeRepository recipeRepository)
        : base(logger, recipeRepository)
    {
    }

    #endregion
}