using Microsoft.AspNetCore.Mvc;
using MyRecipes.Application.CQRS.Commands.Categories;
using MyRecipes.Application.CQRS.Interfaces;
using MyRecipes.Application.CQRS.Queries.Categories;
using MyRecipes.Application.Dtos;

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

    // GET: api/categories
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

    // PUT: api/categories/{id}
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
