using Microsoft.Extensions.Logging;
using MyRecipes.Application.CQRS.Commands.Recipes;
using MyRecipes.Application.CQRS.Interfaces;
using MyRecipes.Application.Dtos;
using MyRecipes.Application.Interfaces.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyRecipes.Application.CQRS.Handlers.Recipes;

/// <summary>
/// Update recipe command handler
/// </summary>
/// <seealso cref="IRequestHandler{UpdateRecipeCommand, RecipeDto}" />
public sealed class UpdateRecipeCommandHandler : IRequestHandler<UpdateRecipeCommand, RecipeDto>
{
    private readonly ILogger<UpdateRecipeCommandHandler> _logger;
    private readonly IRecipeRepository _recipeRepository;

    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateRecipeCommandHandler" /> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="recipeRepository">The recipe repository.</param>
    /// <exception cref="ArgumentNullException">recipeRepository</exception>
    public UpdateRecipeCommandHandler(
        ILogger<UpdateRecipeCommandHandler> logger, 
        IRecipeRepository recipeRepository)
    {
        this._logger = logger
            ?? throw new ArgumentNullException(nameof(logger));
        this._recipeRepository = recipeRepository 
            ?? throw new ArgumentNullException(nameof(recipeRepository));
    }

    #endregion

    #region Methods

    /// <summary>
    /// Handles the specified command.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <returns></returns>
    public async Task<RecipeDto> Handle(UpdateRecipeCommand command)
    {
        var existingRecipe = await this._recipeRepository.GetByIdAsync(command.Id);
        if (existingRecipe != null)
        {
            existingRecipe.Title = command.Dto.Title;
            existingRecipe.Ingredients = command.Dto.Ingredients;
            existingRecipe.Picture = command.Dto.Picture;
            existingRecipe.Process = command.Dto.Process;
            existingRecipe.Notes = command.Dto.Notes;
            existingRecipe.PreparationTime = command.Dto.PreparationTime;
            existingRecipe.NumberOfServings = command.Dto.NumberOfServings;
            existingRecipe.Categories = command.Dto.Categories?.Select(c => c.Id);
            existingRecipe.Tags = command.Dto.Tags?.Select(c => c.Id);

            this._logger.LogInformation("Update recipe with id: {id}", command.Id);
            await this._recipeRepository.UpdateAsync(existingRecipe);
            command.Dto.Id = command.Id;
            return command.Dto;
        }
        return null;
    }

    #endregion
}
