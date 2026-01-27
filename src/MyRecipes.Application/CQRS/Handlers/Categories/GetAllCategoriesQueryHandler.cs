using Microsoft.Extensions.Logging;
using MyRecipes.Application.CQRS.Interfaces;
using MyRecipes.Application.CQRS.Queries.Categories;
using MyRecipes.Application.Dtos;
using MyRecipes.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRecipes.Application.CQRS.Handlers.Categories;

/// <summary>
/// Get all categories query handlers
/// </summary>
/// <seealso cref="IRequestHandler{GetAllCategoriesQuery, IEnumerable{CategoryDto}}" />
public sealed class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryDto>>
{
    private readonly ILogger<GetAllCategoriesQueryHandler> _logger;
    private readonly ICategoryRepository _categoryRepository;

    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="GetAllCategoriesQueryHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="categoryRepository">The category repository.</param>
    /// <exception cref="ArgumentNullException">categoryRepository</exception>
    public GetAllCategoriesQueryHandler(
        ILogger<GetAllCategoriesQueryHandler> logger, 
        ICategoryRepository categoryRepository)
    {
        this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        this._categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
    }

    #endregion

    #region Methods

    /// <summary>
    /// Handles the specified query.
    /// </summary>
    /// <param name="query">The query.</param>
    /// <returns></returns>
    public async Task<IEnumerable<CategoryDto>> Handle(GetAllCategoriesQuery query)
    {
        this._logger.LogInformation("Get all categories");
        var categories = await this._categoryRepository.GetAllAsync();

        return categories?.Select(category => new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Picture = category.Picture,
            Index = category.Index,
            Visibility = category.Visibility,
        }) ?? [];
    }

    #endregion
}
