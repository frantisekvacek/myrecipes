using MyRecipes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyRecipes.Application.Interfaces.Repositories;

/// <summary>
/// Interface for Tag repository
/// </summary>
public interface ITagRepository
{
    #region Methods

    /// <summary>
    /// Gets all asynchronous.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Tag>> GetAllAsync();

    /// <summary>
    /// Gets the by identifier asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    Task<Tag> GetByIdAsync(Guid id);

    /// <summary>
    /// Adds the asynchronous.
    /// </summary>
    /// <param name="tag">The tag.</param>
    /// <returns></returns>
    Task AddAsync(Tag tag);

    /// <summary>
    /// Updates the asynchronous.
    /// </summary>
    /// <param name="tag">The tag.</param>
    /// <returns></returns>
    Task UpdateAsync(Tag tag);

    /// <summary>
    /// Deletes the asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    Task DeleteAsync(Guid id);

    #endregion
}
