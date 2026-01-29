using Microsoft.Extensions.Logging;
using MyRecipes.Application.Dtos;
using MyRecipes.Application.Features.Commands.Base.BaseDelete;
using MyRecipes.Domain.Entities;
using MyRecipes.Domain.Repositories;
using System;

namespace MyRecipes.Application.Features.Commands.Tags.DeleteTag;

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