using MyRecipes.Domain.Entities;
using MyRecipes.Domain.Repositories;
using MyRecipes.Persistence.Context;
using System.Linq;

namespace MyRecipes.Persistence.Repositories;

/// <summary>
/// Tag repository
/// </summary>
/// <seealso cref="BaseRepository{Tag}" />
/// <seealso cref="ITagRepository" />
public class TagRepository : BaseRepository<Tag>, ITagRepository
{
    #region C'to

    /// <summary>
    /// Initializes a new instance of the <see cref="TagRepository"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public TagRepository(MyRecipeDbContext context)
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
    protected override IQueryable<Tag> FullTextSearch(IQueryable<Tag> query, string search)
    {
        return query.Where(r => r.Name.Contains(search));
    }

    #endregion
}