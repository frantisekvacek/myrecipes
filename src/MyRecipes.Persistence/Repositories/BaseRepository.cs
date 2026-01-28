using Microsoft.EntityFrameworkCore;
using MyRecipes.Application.Interfaces.Repositories;
using MyRecipes.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyRecipes.Persistence.Repositories;

/// <summary>
/// Base repository
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
/// <seealso cref="IBaseRepository&lt;TEntity&gt;" />
public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : class
{
    protected readonly MyRecipeDbContext Context;
    protected readonly DbSet<TEntity> DbSet;

    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseRepository{TEntity}"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <exception cref="ArgumentNullException">context</exception>
    protected BaseRepository(MyRecipeDbContext context)
    {
        this.Context = context ?? throw new ArgumentNullException(nameof(context));
        this.DbSet = this.Context.Set<TEntity>();
    }

    #endregion

    #region Methods

    /// <summary>
    /// Gets all asynchronous.
    /// </summary>
    /// <returns></returns>
    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await this.DbSet.ToListAsync();
    }

    /// <summary>
    /// Gets the by identifier asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    public virtual async Task<TEntity> GetByIdAsync(Guid id)
    {
        return await this.DbSet.FindAsync(id);
    }

    /// <summary>
    /// Adds the asynchronous.
    /// </summary>
    /// <param name="entity">The entity.</param>
    public virtual async Task AddAsync(TEntity entity)
    {
        this.DbSet.Add(entity);
        await this.Context.SaveChangesAsync();
    }

    /// <summary>
    /// Updates the asynchronous.
    /// </summary>
    /// <param name="entity">The entity.</param>
    public virtual async Task UpdateAsync(TEntity entity)
    {
        this.DbSet.Update(entity);
        await this.Context.SaveChangesAsync();
    }

    /// <summary>
    /// Deletes the asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    public virtual async Task DeleteAsync(Guid id)
    {
        var entity = await this.GetByIdAsync(id);
        if (entity != null)
        {
            this.DbSet.Remove(entity);
            await this.Context.SaveChangesAsync();
        }

        return;
    }

    #endregion
}