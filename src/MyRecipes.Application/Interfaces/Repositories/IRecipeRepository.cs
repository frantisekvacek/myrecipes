using MyRecipes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyRecipes.Application.Interfaces.Repositories;

/// <summary>
/// Interface for Recipe repository
/// </summary>
public interface IRecipeRepository
{
    #region Methods

    /// <summary>
    /// Gets all asynchronous.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Recipe>> GetAllAsync();

    /// <summary>
    /// Gets the by identifier asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    Task<Recipe> GetByIdAsync(Guid id);

    /// <summary>
    /// Adds the asynchronous.
    /// </summary>
    /// <param name="recipe">The recipe.</param>
    /// <returns></returns>
    Task AddAsync(Recipe recipe);

    /// <summary>
    /// Updates the asynchronous.
    /// </summary>
    /// <param name="recipe">The recipe.</param>
    /// <returns></returns>
    Task UpdateAsync(Recipe recipe);

    /// <summary>
    /// Deletes the asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    Task DeleteAsync(Guid id);

    #endregion
}
