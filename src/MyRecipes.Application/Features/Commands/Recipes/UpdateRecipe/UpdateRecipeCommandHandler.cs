using Microsoft.Extensions.Logging;
using MyRecipes.Application.Dtos;
using MyRecipes.Application.Features.Commands.Base.BaseUpdate;
using MyRecipes.Domain.Entities;
using MyRecipes.Domain.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyRecipes.Application.Features.Commands.Recipes.UpdateRecipe;

/// <summary>
/// Update recipe command handler
/// </summary>
/// <seealso cref="BaseUpdateCommandHandler{UpdateRecipeCommand, Recipe, RecipeDto}" />
public sealed class UpdateRecipeCommandHandler : BaseUpdateCommandHandler<UpdateRecipeCommand, Recipe, RecipeDto>
{
    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateRecipeCommandHandler" /> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="recipeRepository">The category repository.</param>
    /// <exception cref="ArgumentNullException">categoryRepository</exception>
    public UpdateRecipeCommandHandler(
        ILogger<UpdateRecipeCommandHandler> logger,
        IRecipeRepository recipeRepository)
        : base(logger, recipeRepository)
    {
    }

    #endregion

    #region Methods

    /// <summary>
    /// Maps to entity asynchronous.
    /// </summary>
    /// <param name="existingEntity">The existing entity.</param>
    /// <param name="dto">The dto.</param>
    protected override async Task MapToEntityAsync(Recipe existingEntity, RecipeDto dto)
    {
        existingEntity.Title = dto.Title;
        existingEntity.Ingredients = dto.Ingredients;
        existingEntity.Picture = dto.Picture;
        existingEntity.Process = dto.Process;
        existingEntity.Notes = dto.Notes;
        existingEntity.PreparationTime = dto.PreparationTime;
        existingEntity.NumberOfServings = dto.NumberOfServings;
        existingEntity.Categories = dto.Categories?.Select(c => c.Id);
        existingEntity.Tags = dto.Tags?.Select(c => c.Id);
    }

    #endregion
}