using Microsoft.Extensions.Logging;
using MyRecipes.Application.CQRS.Handlers.Base;
using MyRecipes.Application.CQRS.Queries.Tags;
using MyRecipes.Application.Dtos;
using MyRecipes.Application.Interfaces.Repositories;
using MyRecipes.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRecipes.Application.CQRS.Handlers.Tags;

/// <summary>
/// Get all tags query handlers
/// </summary>
/// <seealso cref="BaseGetAllQueryHandler{GetAllTagsQuery, Tag, TagDto}" />
public sealed class GetAllTagsQueryHandler : BaseGetAllQueryHandler<GetAllTagsQuery, Tag, TagDto>
{
    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="GetAllTagsQueryHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="tagRepository">The tag repository.</param>
    public GetAllTagsQueryHandler(
        ILogger<GetAllTagsQueryHandler> logger,
        ITagRepository tagRepository)
        : base(logger, tagRepository)
    {
    }

    #endregion

    #region Methods

    /// <summary>
    /// How entities are mapped to DTOs
    /// </summary>
    protected override async Task<IEnumerable<TagDto>> MapToDtosAsync(IEnumerable<Tag> entities)
    {
        return entities?.Select(category => new TagDto
        {
            Id = category.Id,
            Name = category.Name,
        });
    }

    #endregion
}
