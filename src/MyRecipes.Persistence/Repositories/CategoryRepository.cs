using MyRecipes.Domain.Entities;
using MyRecipes.Domain.Repositories;
using MyRecipes.Persistence.Context;
using System.Linq;

namespace MyRecipes.Persistence.Repositories;

/// <summary>
/// Category repository
/// </summary>
/// <seealso cref="BaseRepository{Category}" />
/// <seealso cref="ICategoryRepository" />
public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    #region C'to

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryRepository"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public CategoryRepository(MyRecipeDbContext context)
        : base(context)
    {
    }

    #endregion

    #region Methods

    /// <summary>
    /// Fulls the text search.
    /// </summary>
    /// <param name="query">The query.</param>
    /// <param name="search">The search.</param>
    /// <returns></returns>
    protected override IQueryable<Category> FullTextSearch(IQueryable<Category> query, string search)
    {
        return query.Where(r => r.Name.Contains(search));
    }

    #endregion
}