using Microsoft.EntityFrameworkCore;
using MyRecipes.Application.Interfaces.Repositories;
using MyRecipes.Domain.Entities;
using MyRecipes.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyRecipes.Persistence.Repositories;

/// <summary>
/// Tag repository
/// </summary>
/// <seealso cref="ITagRepository" />
public class TagRepository : ITagRepository
{
    private readonly MyRecipeDbContext _context;

    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="TagRepository"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public TagRepository(MyRecipeDbContext context)
    {
        this._context = context ?? throw new ArgumentNullException(nameof(context));
    }

    #endregion

    #region Methods

    /// <summary>
    /// Gets all asynchronous.
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Tag>> GetAllAsync()
    {
        return await this._context.Tags?.ToListAsync() ?? [];
    }

    /// <summary>
    /// Gets the by identifier asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    public async Task<Tag> GetByIdAsync(Guid id)
    {
        return await this._context.Tags.FindAsync(id);
    }

    /// <summary>
    /// Adds the asynchronous.
    /// </summary>
    /// <param name="tag">The tag.</param>
    public async Task AddAsync(Tag tag)
    {
        this._context.Tags.Add(tag);
        await this._context.SaveChangesAsync();
    }

    /// <summary>
    /// Updates the asynchronous.
    /// </summary>
    /// <param name="tag">The tag.</param>
    public async Task UpdateAsync(Tag tag)
    {
        this._context.Tags.Update(tag);
        await this._context.SaveChangesAsync();
    }

    /// <summary>
    /// Deletes the asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    public async Task DeleteAsync(Guid id)
    {
        var tag = await this._context.Tags.FindAsync(id);
        if (tag != null)
        {
            this._context.Tags.Remove(tag);
            await this._context.SaveChangesAsync();
        }
    }

    #endregion
}
