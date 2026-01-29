using Microsoft.AspNetCore.Mvc;
using MyRecipes.Application.Commands.Categories.UpdateCategory;
using MyRecipes.Application.Dtos;
using MyRecipes.Application.Interfaces.Mediators;
using MyRecipes.Application.Queries.Categories.GetAllCategories;

namespace MyRecipes.API.Controllers;

/// <summary>
/// Category controller
/// </summary>
/// <seealso cref="ControllerBase" />
[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryController"/> class.
    /// </summary>
    /// <param name="mediator">The mediator.</param>
    public CategoryController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    #endregion

    #region Endpoints

    // GET: api/category
    /// <summary>
    /// Gets all.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await this._mediator.Send(new GetAllCategoriesQuery());
        return this.Ok(response ?? []);
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
        var response = await this._mediator.Send(new UpdateCategoryCommand { Id = id, Dto = dto });
        return response is null
            ? this.NotFound()
            : this.Ok(response);
    }

    #endregion
}
