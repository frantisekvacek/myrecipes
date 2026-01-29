using Microsoft.AspNetCore.Mvc;
using MyRecipes.Application.Dtos;
using MyRecipes.Application.Features.Base;
using MyRecipes.Application.Features.Commands.Categories.UpdateCategory;
using MyRecipes.Application.Features.Commands.Recipes.CreateRecipe;
using MyRecipes.Application.Features.Commands.Recipes.DeleteRecipe;
using MyRecipes.Application.Features.Commands.Recipes.UpdateRecipe;
using MyRecipes.Application.Features.Queries.Categories.GetAllCategories;
using MyRecipes.Application.Features.Queries.Recipes.GetAllRecipes;
using MyRecipes.Application.Features.Queries.Recipes.GetRecipeById;

namespace MyRecipes.API.Controllers;

/// <summary>
/// Recipe controller
/// </summary>
/// <seealso cref="BaseController" />
[ApiController]
[Route("api/[controller]")]
public class RecipeController : BaseController
{
    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="RecipeController"/> class.
    /// </summary>
    /// <param name="mediator">The mediator.</param>
    public RecipeController(IMediator mediator) 
        : base(mediator)
    {
    }

    #endregion

    #region Endpoints

    // GET: api/recipe
    /// <summary>
    /// Gets all.
    /// </summary>
    /// <param name="search">The search.</param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string? search)
    {
        return await this.BaseGetAllAsync<GetAllRecipesQuery, RecipeDto>(new GetAllRecipesQuery { Search = search });
    }

    // GET: api/recipe/{id}
    /// <summary>
    /// Gets the by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return await this.BaseGetByIdAsync<GetRecipeByIdQuery, RecipeDto>(new GetRecipeByIdQuery { Id = id });
    }

    // POST: api/recipe
    /// <summary>
    /// Creates the specified command.
    /// </summary>
    /// <param name="dto">The dto.</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RecipeDto dto)
    {
        return await this.BaseCreateAsync<CreateRecipeCommand, RecipeDto, RecipeDto>(new CreateRecipeCommand { Dto = dto });
    }

    // PUT: api/recipe/{id}
    /// <summary>
    /// Updates the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="dto">The dto.</param>
    /// <returns></returns>
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] RecipeDto dto)
    {
        return await this.BaseUpdateAsync<UpdateRecipeCommand, RecipeDto, RecipeDto>(new UpdateRecipeCommand { Id = id, Dto = dto });
    }

    // DELETE: api/recipe/{id}
    /// <summary>
    /// Deletes the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return await this.BaseDeleteAsync<DeleteRecipeCommand>(new DeleteRecipeCommand { Id = id });
    }

    #endregion
}
