using Microsoft.Extensions.Logging;
using MyRecipes.Application.Dtos;
using MyRecipes.Application.Interfaces.Mediators;
using MyRecipes.Application.Interfaces.Repositories;
using MyRecipes.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace MyRecipes.Application.Commands.Base.BaseDelete;

/// <summary>
/// Base delete command handler
/// </summary>
/// <typeparam name="TCommand">The type of the command.</typeparam>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
/// <typeparam name="TDto">The type of the dto.</typeparam>
/// <seealso cref="IRequestHandler{TCommand, bool}" />
public abstract class BaseDeleteCommandHandler<TCommand, TEntity, TDto>
    : IRequestHandler<TCommand, bool>
    where TCommand : BaseDeleteCommand, IRequest<bool>
    where TEntity : BaseEntity
    where TDto : BaseDto
{
    private readonly ILogger<BaseDeleteCommandHandler<TCommand, TEntity, TDto>> _logger;
    private readonly IBaseRepository<TEntity> _repository;

    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseDeleteCommandHandler{TQuery, TEntity, TDto}"/> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="repository">The repository.</param>
    /// <exception cref="ArgumentNullException">
    /// logger
    /// or
    /// repository
    /// </exception>
    protected BaseDeleteCommandHandler(ILogger<BaseDeleteCommandHandler<TCommand, TEntity, TDto>> logger, IBaseRepository<TEntity> repository)
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
    public async Task<bool> Handle(TCommand command)
    {
        var existingEntity = await this._repository.GetByIdAsync(command.Id);
        if (existingEntity != null)
        {
            this._logger.LogInformation("Delete {Entity} with Id: {id}.", typeof(TEntity).Name, command.Id);
            await this._repository.DeleteAsync(command.Id);

            return true;
        }
        this._logger.LogInformation("{Entity} with Id: {id} was not found!", typeof(TEntity).Name, command.Id);
        return false;
    }

    #endregion
}
