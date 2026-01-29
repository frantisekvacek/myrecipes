using Microsoft.Extensions.Logging;
using MyRecipes.Application.Commands.Base.BaseCreate;
using MyRecipes.Application.Dtos;
using MyRecipes.Application.Interfaces.Repositories;
using MyRecipes.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyRecipes.Application.Commands.Recipes.CreateRecipe;

/// <summary>
/// Creat recipe command handler
/// </summary>
/// <seealso cref="BaseCreateCommandHandler{CreateRecipeCommand, Recipe, RecipeDto}" />
public sealed class CreateRecipeCommandHandler : BaseCreateCommandHandler<CreateRecipeCommand, Recipe, RecipeDto>
{
    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateRecipeCommandHandler" /> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="recipeRepository">The category repository.</param>
    /// <exception cref="ArgumentNullException">categoryRepository</exception>
    public CreateRecipeCommandHandler(
        ILogger<CreateRecipeCommandHandler> logger,
        IRecipeRepository recipeRepository)
        : base(logger, recipeRepository)
    {
    }

    #endregion

    #region Methods

    /// <summary>
    /// Maps to entity asynchronous.
    /// </summary>
    /// <param name="entityId">The entity identifier.</param>
    /// <param name="dto">The dto.</param>
    /// <returns></returns>
    protected override async Task<Recipe> MapToEntityAsync(Guid entityId, RecipeDto dto)
    {
        return new Recipe
        {
            Id = entityId,
            Title = dto.Title,
            Ingredients = dto.Ingredients,
            Picture = dto.Picture,
            Process = dto.Process,
            Notes = dto.Notes,
            PreparationTime = dto.PreparationTime,
            NumberOfServings = dto.NumberOfServings,
            Categories = dto.Categories?.Select(c => c.Id),
            Tags = dto.Tags?.Select(t => t.Id),
        };
    }

    #endregion
}