using MyRecipes.Application.Interfaces.Repositories;
using MyRecipes.Domain.Entities;
using MyRecipes.Persistence.Context;

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
}