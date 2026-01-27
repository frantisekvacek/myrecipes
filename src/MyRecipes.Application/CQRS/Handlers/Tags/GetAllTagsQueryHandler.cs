using Microsoft.Extensions.Logging;
using MyRecipes.Application.CQRS.Interfaces;
using MyRecipes.Application.CQRS.Queries.Tags;
using MyRecipes.Application.Dtos;
using MyRecipes.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRecipes.Application.CQRS.Handlers.Tags;

/// <summary>
/// Get all tags query handlers
/// </summary>
/// <seealso cref="IRequestHandler{GetAllTagsQuery, IEnumerable{TagDto}}" />
public sealed class GetAllTagsQueryHandler : IRequestHandler<GetAllTagsQuery, IEnumerable<TagDto>>
{
    private readonly ILogger<GetAllTagsQueryHandler> _logger;
    private readonly ITagRepository _tagRepository;

    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="GetAllTagsQueryHandler" /> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="tagRepository">The tag repository.</param>
    /// <exception cref="ArgumentNullException">tagRepository</exception>
    public GetAllTagsQueryHandler(
        ILogger<GetAllTagsQueryHandler> logger, 
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
    /// Handles the specified query.
    /// </summary>
    /// <param name="query">The query.</param>
    /// <returns></returns>
    public async Task<IEnumerable<TagDto>> Handle(GetAllTagsQuery query)
    {
        this._logger.LogInformation("Get all tags");
        var tags = await this._tagRepository.GetAllAsync();
        return tags.Select(tag => new TagDto
        {
            Id = tag.Id,
            Name = tag.Name
        });
    }

    #endregion
}
