using Microsoft.EntityFrameworkCore;
using MyRecipes.Application.Interfaces.Repositories;
using MyRecipes.Domain.Entities;
using MyRecipes.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRecipes.Persistence.Repositories;

/// <summary>
/// Recipe repository
/// </summary>
/// <seealso cref="IRecipeRepository" />
public class RecipeRepository : IRecipeRepository
{
    private readonly MyRecipeDbContext _context;

    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="RecipeRepository"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public RecipeRepository(MyRecipeDbContext context)
    {
        this._context = context ?? throw new ArgumentNullException(nameof(context));
    }

    #endregion

    #region Methods

    /// <summary>
    /// Gets all asynchronous.
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Recipe>> GetAllAsync()
    {
        return await this._context.Recipes?.ToListAsync() ?? [];
    }

    /// <summary>
    /// Gets the by identifier asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    public async Task<Recipe> GetByIdAsync(Guid id)
    {
        return await this._context.Recipes.FindAsync(id);
    }

    /// <summary>
    /// Adds the asynchronous.
    /// </summary>
    /// <param name="recipe">The recipe.</param>
    public async Task AddAsync(Recipe recipe)
    {
        this._context.Recipes.Add(recipe);
        await this._context.SaveChangesAsync();
    }

    /// <summary>
    /// Updates the asynchronous.
    /// </summary>
    /// <param name="recipe">The recipe.</param>
    public async Task UpdateAsync(Recipe recipe)
    {
        this._context.Recipes.Update(recipe);
        await this._context.SaveChangesAsync();
    }

    /// <summary>
    /// Deletes the asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    public async Task DeleteAsync(Guid id)
    {
        var recipe = await this._context.Recipes.FindAsync(id);
        if (recipe != null)
        {
            this._context.Recipes.Remove(recipe);
            await this._context.SaveChangesAsync();
        }
    }

    #endregion
}
