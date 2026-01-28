using Microsoft.Extensions.Logging;
using MyRecipes.Application.CQRS.Handlers.Base;
using MyRecipes.Application.CQRS.Queries.Categories;
using MyRecipes.Application.Dtos;
using MyRecipes.Application.Interfaces.Repositories;
using MyRecipes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRecipes.Application.CQRS.Handlers.Categories;

/// <summary>
/// Get all categories query handlers
/// </summary>
/// <seealso cref="BaseGetAllQueryHandler{GetAllCategoriesQuery, Category, CategoryDto}" />
public sealed class GetAllCategoriesQueryHandler : BaseGetAllQueryHandler<GetAllCategoriesQuery, Category, CategoryDto>
{
    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="GetAllCategoriesQueryHandler" /> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="categoryRepository">The category repository.</param>
    /// <exception cref="ArgumentNullException">categoryRepository</exception>
    public GetAllCategoriesQueryHandler(
        ILogger<GetAllCategoriesQueryHandler> logger, 
        ICategoryRepository categoryRepository)
        : base (logger, categoryRepository)
    {
    }

    #endregion

    #region Methods

    /// <summary>
    /// How entities are mapped to DTOs
    /// </summary>
    protected override async Task<IEnumerable<CategoryDto>> MapToDtosAsync(IEnumerable<Category> entities)
    {
        return entities?.Select(category => new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Picture = category.Picture,
            Index = category.Index,
            Visibility = category.Visibility,
        });
    }

    #endregion
}
