using Microsoft.Extensions.Logging;
using MyRecipes.Application.Commands.Base.BaseUpdate;
using MyRecipes.Application.Dtos;
using MyRecipes.Application.Interfaces.Repositories;
using MyRecipes.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace MyRecipes.Application.Commands.Tags.UpdateTag;

/// <summary>
/// Update tag command handler
/// </summary>
/// <seealso cref="BaseUpdateCommandHandler{UpdateTagCommand, Tag, TagDto}" />
public sealed class UpdateTagCommandHandler : BaseUpdateCommandHandler<UpdateTagCommand, Tag, TagDto>
{
    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateTagCommandHandler" /> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="tagRepository">The tag repository.</param>
    /// <exception cref="ArgumentNullException">categoryRepository</exception>
    public UpdateTagCommandHandler(
        ILogger<UpdateTagCommandHandler> logger,
        ITagRepository tagRepository)
        : base(logger, tagRepository)
    {
    }

    #endregion

    #region Methods

    /// <summary>
    /// Maps to entity asynchronous.
    /// </summary>
    /// <param name="existingEntity">The existing entity.</param>
    /// <param name="dto">The dto.</param>
    protected override async Task MapToEntityAsync(Tag existingEntity, TagDto dto)
    {
        existingEntity.Name = dto.Name;
    }

    #endregion
}