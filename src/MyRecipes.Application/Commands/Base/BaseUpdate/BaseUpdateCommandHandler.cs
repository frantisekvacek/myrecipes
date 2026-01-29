using Microsoft.Extensions.Logging;
using MyRecipes.Application.Dtos;
using MyRecipes.Application.Interfaces.Mediators;
using MyRecipes.Application.Interfaces.Repositories;
using MyRecipes.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace MyRecipes.Application.Commands.Base.BaseUpdate;

/// <summary>
/// Base update command gandler
/// </summary>
/// <typeparam name="TCommand">The type of the command.</typeparam>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
/// <typeparam name="TDto">The type of the dto.</typeparam>
/// <seealso cref="IRequestHandler{TCommand, TDto}" />
public abstract class BaseUpdateCommandHandler<TCommand, TEntity, TDto>
    : IRequestHandler<TCommand, TDto>
    where TCommand : BaseUpdateCommand<TDto, TDto>, IRequest<TDto>
    where TEntity : BaseEntity
    where TDto : BaseDto
{
    private readonly ILogger<BaseUpdateCommandHandler<TCommand, TEntity, TDto>> _logger;
    private readonly IBaseRepository<TEntity> _repository;

    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseUpdateCommandHandler{TQuery, TEntity, TDto}"/> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="repository">The repository.</param>
    /// <exception cref="ArgumentNullException">
    /// logger
    /// or
    /// repository
    /// </exception>
    protected BaseUpdateCommandHandler(ILogger<BaseUpdateCommandHandler<TCommand, TEntity, TDto>> logger, IBaseRepository<TEntity> repository)
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
        var existingEntity = await this._repository.GetByIdAsync(command.Id);
        if (existingEntity != null)
        {
            this._logger.LogInformation("Update {Entity} with Id: {id}.", typeof(TEntity).Name, command.Id);
            await this.MapToEntityAsync(existingEntity, command.Dto);

            
            await this._repository.UpdateAsync(existingEntity);

            command.Dto.Id = command.Id;
            return command.Dto;
        }
        this._logger.LogInformation("{Entity} with Id: {id} was not found!", typeof(TEntity).Name, command.Id);
        return null;
    }

    /// <summary>
    /// Maps to entity asynchronous.
    /// </summary>
    /// <param name="existingEntity">The existing entity.</param>
    /// <param name="dto">The dto.</param>
    /// <returns></returns>
    protected abstract Task MapToEntityAsync(TEntity existingEntity, TDto dto);

    #endregion
}
