using Microsoft.AspNetCore.Mvc;
using MyRecipes.Application.Dtos;
using MyRecipes.Application.Features.Base;
using MyRecipes.Application.Features.Commands.Base.BaseCreate;
using MyRecipes.Application.Features.Commands.Base.BaseDelete;
using MyRecipes.Application.Features.Commands.Base.BaseUpdate;
using MyRecipes.Application.Features.Queries.Base.BaseGetAll;
using MyRecipes.Application.Features.Queries.Base.BaseGetById;

namespace MyRecipes.API.Controllers;

/// <summary>
/// Base controller
/// </summary>
/// <seealso cref="ControllerBase" />
[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    private const string CCreateActionName = "Create";

    private readonly IMediator _mediator;

    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseController"/> class.
    /// </summary>
    /// <param name="mediator">The mediator.</param>
    public BaseController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Oks the or not found.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="response">The response.</param>
    /// <returns></returns>
    protected IActionResult OkOrNotFound<T>(T? response)
        where T : class
    {
        return response is null ? this.NotFound() : this.Ok(response);
    }

    /// <summary>
    /// Noes the content or not found.
    /// </summary>
    /// <param name="success">if set to <c>true</c> [success].</param>
    /// <returns></returns>
    protected IActionResult NoContentOrNotFound(bool success)
    {
        return success ? this.NoContent() : this.NotFound();
    }

    #endregion

    #region Endpoints

    /// <summary>
    /// Bases the get all asynchronous.
    /// </summary>
    /// <typeparam name="TQuery">The type of the query.</typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    /// <param name="query">The query.</param>
    /// <returns></returns>
    protected async Task<IActionResult> BaseGetAllAsync<TQuery, TResponse>(TQuery query)
        where TQuery : BaseGetAllQuery<TResponse>
    {
        var response = await this._mediator.Send(query);
        return this.Ok(response ?? []);
    }

    /// <summary>
    /// Bases the get by identifier asynchronous.
    /// </summary>
    /// <typeparam name="TQuery">The type of the query.</typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    /// <param name="query">The query.</param>
    /// <returns></returns>
    protected async Task<IActionResult> BaseGetByIdAsync<TQuery, TResponse>(TQuery query)
        where TQuery : BaseGetByIdQuery<TResponse>
    {
        var response = await this._mediator.Send(query);
        return response is null
            ? this.NotFound()
            : this.Ok(response);
    }

    /// <summary>
    /// Bases the create asynchronous.
    /// </summary>
    /// <typeparam name="TCommand">The type of the command.</typeparam>
    /// <typeparam name="TDto">The type of the dto.</typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    /// <param name="command">The command.</param>
    /// <returns></returns>
    protected async Task<IActionResult> BaseCreateAsync<TCommand, TDto, TResponse>(TCommand command)
        where TCommand : BaseCreateCommand<TDto, TResponse>
        where TResponse : BaseDto
    {
        var response = await this._mediator.Send(command);
        return this.CreatedAtAction(CCreateActionName, response.Id, response);
    }

    /// <summary>
    /// Bases the update asynchronous.
    /// </summary>
    /// <typeparam name="TCommand">The type of the command.</typeparam>
    /// <typeparam name="TDto">The type of the dto.</typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    /// <param name="command">The command.</param>
    /// <returns></returns>
    protected async Task<IActionResult> BaseUpdateAsync<TCommand, TDto, TResponse>(TCommand command)
        where TCommand : BaseUpdateCommand<TDto, TResponse>
    {
        var response = await this._mediator.Send(command);
        return response is null
            ? this.NotFound()
            : this.Ok(response);
    }

    /// <summary>
    /// Bases the delete asynchronous.
    /// </summary>
    /// <typeparam name="TCommand">The type of the command.</typeparam>
    /// <param name="command">The command.</param>
    /// <returns></returns>
    protected async Task<IActionResult> BaseDeleteAsync<TCommand>(TCommand command)
        where TCommand : BaseDeleteCommand
    {
        var response = await this._mediator.Send(command);
        return response
            ? this.NoContent()
            : this.NotFound();
    }

    #endregion
}
