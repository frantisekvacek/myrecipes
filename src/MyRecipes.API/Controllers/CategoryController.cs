using Microsoft.AspNetCore.Mvc;
using MyRecipes.Application.Dtos;
using MyRecipes.Application.Features.Base;
using MyRecipes.Application.Features.Commands.Categories.UpdateCategory;
using MyRecipes.Application.Features.Queries.Categories.GetAllCategories;

namespace MyRecipes.API.Controllers;

/// <summary>
/// Category controller
/// </summary>
/// <seealso cref="BaseController" />
public class CategoryController : BaseController
{
    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryController" /> class.
    /// </summary>
    /// <param name="mediator">The mediator.</param>
    public CategoryController(IMediator mediator) 
        : base(mediator)
    {
    }

    #endregion

    #region Endpoints

    // GET: api/category
    /// <summary>
    /// Gets all.
    /// </summary>
    /// <param name="search">The search.</param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string? search)
    {
        return await this.BaseGetAllAsync<GetAllCategoriesQuery, CategoryDto>(new GetAllCategoriesQuery { Search = search });
    }

    // PUT: api/category/{id}
    /// <summary>
    /// Updates the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="dto">The dto.</param>
    /// <returns></returns>
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] CategoryDto dto)
    {
        return await this.BaseUpdateAsync<UpdateCategoryCommand, CategoryDto, CategoryDto>(new UpdateCategoryCommand { Id = id, Dto = dto });
    }

    #endregion
}
