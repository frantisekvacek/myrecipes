using MyRecipes.Domain.Entities;

namespace MyRecipes.Application.Interfaces.Repositories;

/// <summary>
/// Interface for Category repository
/// </summary>
/// <seealso cref="IBaseRepository{Category}" />
public interface ICategoryRepository : IBaseRepository<Category>
{
}
