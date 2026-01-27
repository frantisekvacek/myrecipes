using Microsoft.AspNetCore.Mvc;
using MyRecipes.Application.CQRS.Commands.Tags;
using MyRecipes.Application.CQRS.Interfaces;
using MyRecipes.Application.CQRS.Queries.Tags;
using MyRecipes.Application.Dtos;

namespace MyRecipes.API.Controllers;

/// <summary>
/// Tag controller
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class TagController : ControllerBase
{
    private readonly IMediator _mediator;

    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="TagController"/> class.
    /// </summary>
    /// <param name="mediator">The mediator.</param>
    public TagController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    #endregion

    #region Endpoints

    // GET: api/tag
    /// <summary>
    /// Gets all.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await this._mediator.Send(new GetAllTagsQuery());
        return this.Ok(response ?? []);
    }

    // POST: api/tag
    /// <summary>
    /// Creates the specified command.
    /// </summary>
    /// <param name="dto">The dto.</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TagDto dto)
    {
        var response = await this._mediator.Send(new CreateTagCommand { Dto = dto });
        return this.CreatedAtAction(nameof(this.Create), response.Id, response);
    }

    // PUT: api/tag/{id}
    /// <summary>
    /// Updates the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="dto">The dto.</param>
    /// <returns></returns>
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] TagDto dto)
    {
        var response = await this._mediator.Send(new UpdateTagCommand { Id = id, Dto = dto });
        return response is null
            ? this.NotFound()
            : this.Ok(response);
    }

    // DELETE: api/tag/{id}
    /// <summary>
    /// Deletes the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await this._mediator.Send(new DeleteTagCommand { Id = id });
        return response
            ? this.NoContent()
            : this.NotFound();
    }

    #endregion
}
