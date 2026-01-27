using Microsoft.Extensions.Logging;
using MyRecipes.Application.CQRS.Commands.Tags;
using MyRecipes.Application.CQRS.Interfaces;
using MyRecipes.Application.Dtos;
using MyRecipes.Application.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace MyRecipes.Application.CQRS.Handlers.Tags;

/// <summary>
/// Update tag command handler
/// </summary>
/// <seealso cref="IRequestHandler{UpdateTagCommand, TagDto}" />
public sealed class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand, TagDto>
{
    private readonly ILogger<UpdateTagCommandHandler> _logger;
    private readonly ITagRepository _tagRepository;

    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateTagCommandHandler" /> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="tagRepository">The tag repository.</param>
    /// <exception cref="ArgumentNullException">tagRepository</exception>
    public UpdateTagCommandHandler(
        ILogger<UpdateTagCommandHandler> logger, 
        ITagRepository tagRepository)
    {
        this._logger = logger
            ?? throw new ArgumentNullException(nameof(logger));
        this._tagRepository = tagRepository 
            ?? throw new ArgumentNullException(nameof(tagRepository));
    }

    #endregion

    #region Methods

    /// <summary>
    /// Handles the specified command.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <returns></returns>
    public async Task<TagDto> Handle(UpdateTagCommand command)
    {
        var existingTab = await this._tagRepository.GetByIdAsync(command.Id);
        if (existingTab != null)
        {
            existingTab.Name = command.Dto.Name;

            this._logger.LogInformation("Update recipe with id: {id}", command.Id);
            await this._tagRepository.UpdateAsync(existingTab);
            command.Dto.Id = command.Id;
            return command.Dto;
        }
        return null;
    }

    #endregion
}
