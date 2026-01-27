using Microsoft.EntityFrameworkCore;
using MyRecipes.Application.Interfaces.Repositories;
using MyRecipes.Domain.Entities;
using MyRecipes.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyRecipes.Persistence.Repositories;

/// <summary>
/// Category repository
/// </summary>
/// <seealso cref="ICategoryRepository" />
public class CategoryRepository : ICategoryRepository
{
    private readonly MyRecipeDbContext _context;

    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryRepository"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public CategoryRepository(MyRecipeDbContext context)
    {
        this._context = context ?? throw new ArgumentNullException(nameof(context));
    }

    #endregion

    #region Methods

    /// <summary>
    /// Gets all asynchronous.
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await this._context.Categories?.ToListAsync() ?? [];
    }

    /// <summary>Gets the by identifier asynchronous.</summary>
    /// <param name="id">The identifier.</param>
    /// <returns>
    ///   <br />
    /// </returns>
    public async Task<Category> GetByIdAsync(Guid id)
    {
        return await this._context.Categories.FindAsync(id);
    }

    /// <summary>Updates the asynchronous.</summary>
    /// <param name="category">The category.</param>
    public async Task UpdateAsync(Category category)
    {
        this._context.Categories.Update(category);
        await this._context.SaveChangesAsync();
    }

    #endregion
}

