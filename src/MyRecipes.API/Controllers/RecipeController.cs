using Microsoft.AspNetCore.Mvc;
using MyRecipes.Application.CQRS.Commands.Recipes;
using MyRecipes.Application.CQRS.Interfaces;
using MyRecipes.Application.CQRS.Queries.Recipes;
using MyRecipes.Application.Dtos;

namespace MyRecipes.API.Controllers;

/// <summary>
/// Recipe controller
/// </summary>
/// <seealso cref="ControllerBase" />
[ApiController]
[Route("api/[controller]")]
public class RecipeController : ControllerBase
{
    private readonly IMediator _mediator;

    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="RecipeController"/> class.
    /// </summary>
    /// <param name="mediator">The mediator.</param>
    public RecipeController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    #endregion

    #region Endpoints

    // GET: api/recipes
    /// <summary>
    /// Gets all.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await this._mediator.Send(new GetAllRecipesQuery());
        return this.Ok(response ?? []);
    }

    // GET: api/recipes/{id}
    /// <summary>
    /// Gets the by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var response = await this._mediator.Send(new GetRecipeByIdQuery { Id = id });
        return response is null 
            ? this.NotFound() 
            : this.Ok(response);
    }

    // POST: api/recipes
    /// <summary>
    /// Creates the specified command.
    /// </summary>
    /// <param name="dto">The dto.</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RecipeDto dto)
    {
        var response = await this._mediator.Send(new CreateRecipeCommand { Dto = dto});
        return this.CreatedAtAction(nameof(this.Create), response.Id, response);
    }

    // PUT: api/recipes/{id}
    /// <summary>
    /// Updates the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="dto">The dto.</param>
    /// <returns></returns>
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] RecipeDto dto)
    {
        var response = await this._mediator.Send(new UpdateRecipeCommand { Id = id, Dto = dto});
        return response is null
            ? this.NotFound()
            : this.Ok(response);
    }

    // DELETE: api/recipes/{id}
    /// <summary>
    /// Deletes the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _mediator.Send(new DeleteRecipeCommand { Id = id });
        return response 
            ? this.NoContent() 
            : this.NotFound();
    }

    #endregion
}
