using MyRecipes.Domain.Entities;
using MyRecipes.Domain.Repositories;
using MyRecipes.Persistence.Context;

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
}