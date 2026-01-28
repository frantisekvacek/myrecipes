using Microsoft.Extensions.Logging;
using MyRecipes.Application.CQRS.Interfaces;
using MyRecipes.Application.CQRS.Queries.Base;
using MyRecipes.Application.Interfaces.Repositories;
using MyRecipes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyRecipes.Application.CQRS.Handlers.Base;

/// <summary>
/// Base get by id query handler
/// </summary>
/// <typeparam name="TQuery">The type of the query.</typeparam>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
/// <typeparam name="TDto">The type of the dto.</typeparam>
/// <seealso cref="IRequestHandler{TQuery, IEnumerable{TDto}" />
public abstract class BaseGetByIdQueryHandler<TQuery, TEntity, TDto>
    : IRequestHandler<TQuery, TDto>
    where TQuery : BaseGetByIdQuery<TDto>, IRequest<TDto>
    where TEntity : BaseEntity
{
    private readonly ILogger _logger;
    private readonly IBaseRepository<TEntity> _repository;

    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseGetByIdQueryHandler{TQuery, TEntity, TDto}"/> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="repository">The repository.</param>
    /// <exception cref="ArgumentNullException">
    /// logger
    /// or
    /// repository
    /// </exception>
    protected BaseGetByIdQueryHandler(ILogger logger, IBaseRepository<TEntity> repository)
    {
        this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    #endregion

    #region Methods

    /// <summary>
    /// Handles the specified query.
    /// </summary>
    /// <param name="query">The query.</param>
    /// <returns></returns>
    public async Task<TDto> Handle(TQuery query)
    {
        this._logger.LogInformation("Get {Entity} by Id: {Id}.", typeof(TEntity).Name, query.Id);

        var entity = await this._repository.GetByIdAsync(query.Id);
        return await this.MapToDtoAsync(entity);
    }

    /// <summary>
    /// Maps to dto asynchronous.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns></returns>
    protected abstract Task<TDto> MapToDtoAsync(TEntity entity);

    #endregion
}
