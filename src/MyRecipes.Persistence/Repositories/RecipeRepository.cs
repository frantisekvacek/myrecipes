using MyRecipes.Domain.Entities;
using MyRecipes.Domain.Repositories;
using MyRecipes.Persistence.Context;
using System.Linq;

namespace MyRecipes.Persistence.Repositories;

/// <summary>
/// Recipe repository
/// </summary>
/// <seealso cref="BaseRepository{Recipe}" />
/// <seealso cref="IRecipeRepository" />
public class RecipeRepository : BaseRepository<Recipe>, IRecipeRepository
{
    #region C'to

    /// <summary>
    /// Initializes a new instance of the <see cref="TagRepository"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public RecipeRepository(MyRecipeDbContext context)
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
    protected override IQueryable<Recipe> FullTextSearch(IQueryable<Recipe> query, string search)
    {
        return query.Where(r => r.Title.Contains(search));
    }

    #endregion
}