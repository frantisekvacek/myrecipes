using Microsoft.Extensions.Logging;
using MyRecipes.Application.CQRS.Commands.Recipes;
using MyRecipes.Application.CQRS.Interfaces;
using MyRecipes.Application.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace MyRecipes.Application.CQRS.Handlers.Recipes;

/// <summary>
/// Delete recipe command handler
/// </summary>
/// <seealso cref="IRequestHandler{DeleteRecipeCommand, bool}" />
public sealed class DeleteRecipeCommandHandler : IRequestHandler<DeleteRecipeCommand, bool>
{
    private readonly ILogger<DeleteRecipeCommandHandler> _logger;
    private readonly IRecipeRepository _recipeRepository;

    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteRecipeCommandHandler" /> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="recipeRepository">The recipe repository.</param>
    /// <exception cref="ArgumentNullException">recipeRepository</exception>
    public DeleteRecipeCommandHandler(
        ILogger<DeleteRecipeCommandHandler> logger, 
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
    public async Task<bool> Handle(DeleteRecipeCommand command)
    {
        var existingRecipe = await this._recipeRepository.GetByIdAsync(command.Id);
        if (existingRecipe != null)
        {
            this._logger.LogInformation("Delete recipe with id: {id}", command.Id);
            await this._recipeRepository.DeleteAsync(command.Id);
            return true;
        }
        return false;
    }

    #endregion
}
