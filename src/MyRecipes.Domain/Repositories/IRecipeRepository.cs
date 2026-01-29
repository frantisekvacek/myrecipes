using MyRecipes.Domain.Entities;

namespace MyRecipes.Domain.Repositories;

/// <summary>
/// Interface for Recipe repository
/// </summary>
/// <seealso cref="IBaseRepository{Recipe}" />
public interface IRecipeRepository : IBaseRepository<Recipe>
{
}
