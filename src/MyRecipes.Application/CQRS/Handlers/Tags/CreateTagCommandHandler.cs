using Microsoft.Extensions.Logging;
using MyRecipes.Application.CQRS.Commands.Tags;
using MyRecipes.Application.CQRS.Interfaces;
using MyRecipes.Application.Dtos;
using MyRecipes.Application.Interfaces.Repositories;
using MyRecipes.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace MyRecipes.Application.CQRS.Handlers.Tags;

/// <summary>
/// Create tag command handler
/// </summary>
/// <seealso cref="IRequestHandler{CreateTagCommand, TagDto}" />
public sealed class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, TagDto>
{
    private readonly ILogger<CreateTagCommandHandler> _logger;
    private readonly ITagRepository _tagRepository;

    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateTagCommandHandler" /> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="tagRepository">The tag repository.</param>
    /// <exception cref="ArgumentNullException">tagRepository</exception>
    public CreateTagCommandHandler(
        ILogger<CreateTagCommandHandler> logger, 
        ITagRepository tagRepository)
    {
        this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        this._tagRepository = tagRepository ?? throw new ArgumentNullException(nameof(tagRepository));
    }

    #endregion

    #region Methods

    /// <summary>
    /// Handles the specified command.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <returns></returns>
    public async Task<TagDto> Handle(CreateTagCommand command)
    {
        var tag = new Tag
        {
            Id = Guid.NewGuid(),
            Name = command.Dto.Name,
        };

        this._logger.LogInformation("Create tag with id: {id}", tag.Id);
        await this._tagRepository.AddAsync(tag);

        command.Dto.Id = tag.Id;
        return command.Dto;
    }

    #endregion
}
