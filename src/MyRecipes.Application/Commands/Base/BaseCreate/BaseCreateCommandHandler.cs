using Microsoft.Extensions.Logging;
using MyRecipes.Application.Dtos;
using MyRecipes.Application.Interfaces.Mediators;
using MyRecipes.Application.Interfaces.Repositories;
using MyRecipes.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace MyRecipes.Application.Commands.Base.BaseCreate;

/// <summary>
/// Base create command handler
/// </summary>
/// <typeparam name="TCommand">The type of the command.</typeparam>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
/// <typeparam name="TDto">The type of the dto.</typeparam>
/// <seealso cref="IRequestHandler{TCommand, TDto}" />
public abstract class BaseCreateCommandHandler<TCommand, TEntity, TDto>
    : IRequestHandler<TCommand, TDto>
    where TCommand : BaseCreateCommand<TDto, TDto>, IRequest<TDto>
    where TEntity : BaseEntity
    where TDto : BaseDto
{
    private readonly ILogger<BaseCreateCommandHandler<TCommand, TEntity, TDto>> _logger;
    private readonly IBaseRepository<TEntity> _repository;

    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseCreateCommandHandler{TQuery, TEntity, TDto}"/> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="repository">The repository.</param>
    /// <exception cref="ArgumentNullException">
    /// logger
    /// or
    /// repository
    /// </exception>
    protected BaseCreateCommandHandler(ILogger<BaseCreateCommandHandler<TCommand, TEntity, TDto>> logger, IBaseRepository<TEntity> repository)
    {
        this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    #endregion

    #region Methods

    /// <summary>
    /// Handles the specified query.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <returns></returns>
    public async Task<TDto> Handle(TCommand command)
    {
        var entityId = Guid.NewGuid();
        this._logger.LogInformation("Create {Entity} with Id: {Id}.", typeof(TEntity).Name, entityId);

        var entity = await this.MapToEntityAsync(entityId, command.Dto);

        await this._repository.AddAsync(entity);

        command.Dto.Id = entity.Id;
        return command.Dto;
    }

    /// <summary>
    /// Maps to entity asynchronous.
    /// </summary>
    /// <param name="entityId">The entity identifier.</param>
    /// <param name="dto">The dto.</param>
    /// <returns></returns>
    protected abstract Task<TEntity> MapToEntityAsync(Guid entityId, TDto dto);

    #endregion
}
