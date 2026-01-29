using Microsoft.Extensions.Logging;
using MyRecipes.Application.Features.Base;
using MyRecipes.Domain.Entities;
using MyRecipes.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRecipes.Application.Features.Queries.Base.BaseGetAll;

/// <summary>
/// Base get all query handler
/// </summary>
/// <typeparam name="TQuery">The type of the query.</typeparam>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
/// <typeparam name="TDto">The type of the dto.</typeparam>
/// <seealso cref="IRequestHandler{TQuery, IEnumerable{TDto}}" />
public abstract class BaseGetAllQueryHandler<TQuery, TEntity, TDto>
    : IRequestHandler<TQuery, IEnumerable<TDto>>
    where TQuery : BaseGetAllQuery<TDto>, IRequest<IEnumerable<TDto>>
    where TEntity : BaseEntity
{
    protected readonly ILogger<BaseGetAllQueryHandler<TQuery, TEntity, TDto>> Logger;
    protected readonly IBaseRepository<TEntity> Repository;

    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseGetAllQueryHandler{TQuery, TEntity, TDto}"/> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="repository">The repository.</param>
    /// <exception cref="ArgumentNullException">
    /// logger
    /// or
    /// repository
    /// </exception>
    protected BaseGetAllQueryHandler(ILogger<BaseGetAllQueryHandler<TQuery, TEntity, TDto>> logger, IBaseRepository<TEntity> repository)
    {
        this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        this.Repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    #endregion

    #region Methods

    /// <summary>
    /// Handles the specified query.
    /// </summary>
    /// <param name="query">The query.</param>
    /// <returns></returns>
    public async Task<IEnumerable<TDto>> Handle(TQuery query)
    {
        this.Logger.LogInformation("Get all {Entity}(s).", typeof(TEntity).Name);

        var entities = await this.Repository.GetAllAsync();
        return entities == null || !entities.Any() 
            ? [] 
            : await this.MapToDtosAsync(entities);
    }

    /// <summary>
    /// How entities are mapped to DTOs
    /// </summary>
    protected abstract Task<IEnumerable<TDto>> MapToDtosAsync(IEnumerable<TEntity> entities);

    #endregion
}
