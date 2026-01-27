using MyRecipes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyRecipes.Application.Interfaces.Repositories;

/// <summary>
/// Interface for Category repository
/// </summary>
public interface ICategoryRepository
{
    #region Methods

    /// <summary>
    /// Gets all asynchronous.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Category>> GetAllAsync();

    /// <summary>
    /// Gets the by identifier asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    Task<Category> GetByIdAsync(Guid id);

    /// <summary>
    /// Updates the asynchronous.
    /// </summary>
    /// <param name="category">The category.</param>
    /// <returns></returns>
    Task UpdateAsync(Category category);

    #endregion
}
