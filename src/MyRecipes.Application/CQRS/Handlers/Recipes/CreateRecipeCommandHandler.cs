using Microsoft.Extensions.Logging;
using MyRecipes.Application.CQRS.Commands.Recipes;
using MyRecipes.Application.CQRS.Interfaces;
using MyRecipes.Application.Dtos;
using MyRecipes.Application.Interfaces.Repositories;
using MyRecipes.Domain.Entities;
using System;
using System.Linq;  
using System.Threading.Tasks;

namespace MyRecipes.Application.CQRS.Handlers.Recipes;

/// <summary>
/// Creat recipe command handler
/// </summary>
/// <seealso cref="IRequestHandler{CreateRecipeCommand, RecipeDto}" />
public sealed class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, RecipeDto>
{
    private readonly ILogger<CreateRecipeCommandHandler> _logger;
    private readonly IRecipeRepository _recipeRepository;

    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateRecipeCommandHandler" /> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="recipeRepository">The recipe repository.</param>
    /// <exception cref="ArgumentNullException">recipeRepository</exception>
    public CreateRecipeCommandHandler(
        ILogger<CreateRecipeCommandHandler> logger, 
        IRecipeRepository recipeRepository)
    {
        this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        this._recipeRepository = recipeRepository ?? throw new ArgumentNullException(nameof(recipeRepository));
    }

    #endregion

    #region Methods

    /// <summary>
    /// Handles the specified command.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <returns></returns>
    public async Task<RecipeDto> Handle(CreateRecipeCommand command)
    {
        var recipe = new Recipe
        {
            Id = Guid.NewGuid(),
            Title = command.Dto.Title,
            Ingredients = command.Dto.Ingredients,
            Picture = command.Dto.Picture,
            Process = command.Dto.Process,
            Notes = command.Dto.Notes,
            PreparationTime = command.Dto.PreparationTime,
            NumberOfServings = command.Dto.NumberOfServings,
            Categories = command.Dto.Categories?.Select(c => c.Id),
            Tags = command.Dto.Tags?.Select(t => t.Id),
        };

        this._logger.LogInformation("Create recipe with id: {id}", recipe.Id);
        await this._recipeRepository.AddAsync(recipe);

        command.Dto.Id = recipe.Id;
        return command.Dto;
    }

    #endregion
}
