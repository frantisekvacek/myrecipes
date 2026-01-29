using Microsoft.Extensions.Logging;
using MyRecipes.Application.Dtos;
using MyRecipes.Application.Features.Base;
using MyRecipes.Application.Features.Commands.Base.BaseCreate;
using MyRecipes.Domain.Entities;
using MyRecipes.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace MyRecipes.Application.Features.Commands.Tags.CreateTag;

/// <summary>
/// Create tag command handler
/// </summary>
/// <seealso cref="IRequestHandler{CreateTagCommand, TagDto}" />
public sealed class CreateTagCommandHandler : BaseCreateCommandHandler<CreateTagCommand, Tag, TagDto>
{
    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateTagCommandHandler" /> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="tagRepository">The tag repository.</param>
    /// <exception cref="ArgumentNullException">categoryRepository</exception>
    public CreateTagCommandHandler(
        ILogger<CreateTagCommandHandler> logger,
        ITagRepository tagRepository)
        : base(logger, tagRepository)
    {
    }

    #endregion

    #region Methods

    /// <summary>
    /// Maps to entity asynchronous.
    /// </summary>
    /// <param name="entityId">The entity identifier.</param>
    /// <param name="dto">The dto.</param>
    /// <returns></returns>
    protected override async Task<Tag> MapToEntityAsync(Guid entityId, TagDto dto)
    {
        return new Tag
        {
            Id = entityId,
            Name = dto.Name,
        };
    }

    #endregion
}