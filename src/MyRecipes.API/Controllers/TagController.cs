using Microsoft.AspNetCore.Mvc;
using MyRecipes.Application.Dtos;
using MyRecipes.Application.Features.Base;
using MyRecipes.Application.Features.Commands.Tags.CreateTag;
using MyRecipes.Application.Features.Commands.Tags.DeleteTag;
using MyRecipes.Application.Features.Commands.Tags.UpdateTag;
using MyRecipes.Application.Features.Queries.Tags.GetAllTags;

namespace MyRecipes.API.Controllers;

/// <summary>
/// Tag controller
/// </summary>
/// <seealso cref="BaseController" />
[ApiController]
[Route("api/[controller]")]
public class TagController : BaseController
{
    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="TagController"/> class.
    /// </summary>
    /// <param name="mediator">The mediator.</param>
    public TagController(IMediator mediator) 
        : base(mediator)
    {
    }

    #endregion

    #region Endpoints

    // GET: api/tag
    /// <summary>
    /// Gets all.
    /// </summary>
    /// <param name="search">The search.</param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string? search)
    {
        return await this.BaseGetAllAsync<GetAllTagsQuery, TagDto>(new GetAllTagsQuery { Search = search });
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
        return await this.BaseCreateAsync<CreateTagCommand, TagDto, TagDto>(new CreateTagCommand { Dto = dto });
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
        return await this.BaseUpdateAsync<UpdateTagCommand, TagDto, TagDto>(new UpdateTagCommand { Id = id, Dto = dto });
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
        return await this.BaseDeleteAsync<DeleteTagCommand>(new DeleteTagCommand { Id = id });
    }

    #endregion
}
