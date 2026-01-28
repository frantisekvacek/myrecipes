using Microsoft.Extensions.Logging;
using MyRecipes.Application.CQRS.Commands.Recipes;
using MyRecipes.Application.CQRS.Commands.Tags;
using MyRecipes.Application.CQRS.Handlers.Base;
using MyRecipes.Application.CQRS.Interfaces;
using MyRecipes.Application.Dtos;
using MyRecipes.Application.Interfaces.Repositories;
using MyRecipes.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyRecipes.Application.CQRS.Handlers.Tags;

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