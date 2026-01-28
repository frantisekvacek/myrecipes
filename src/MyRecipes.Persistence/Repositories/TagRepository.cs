using MyRecipes.Application.Interfaces.Repositories;
using MyRecipes.Domain.Entities;
using MyRecipes.Persistence.Context;

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
}