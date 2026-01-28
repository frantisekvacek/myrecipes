using Microsoft.Extensions.Logging;
using MyRecipes.Application.CQRS.Commands.Tags;
using MyRecipes.Application.CQRS.Handlers.Base;
using MyRecipes.Application.Dtos;
using MyRecipes.Application.Interfaces.Repositories;
using MyRecipes.Domain.Entities;
using System;

namespace MyRecipes.Application.CQRS.Handlers.Tags;

/// <summary>
/// Delete tag command handler
/// </summary>
/// <seealso cref="BaseDeleteCommandHandler{DeleteTagCommand, Tag, TagDto}" />
public sealed class DeleteTagCommandHandler : BaseDeleteCommandHandler<DeleteTagCommand, Tag, TagDto>
{
    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteTagCommandHandler" /> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="tagRepository">The tag repository.</param>
    /// <exception cref="ArgumentNullException">categoryRepository</exception>
    public DeleteTagCommandHandler(
        ILogger<DeleteTagCommandHandler> logger,
        ITagRepository tagRepository)
        : base(logger, tagRepository)
    {
    }

    #endregion
}