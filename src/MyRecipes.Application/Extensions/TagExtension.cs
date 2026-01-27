using MyRecipes.Application.Dtos;
using MyRecipes.Application.Interfaces.Repositories;
using MyRecipes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRecipes.Application.Extensions;

/// <summary>
/// Tag extension
/// </summary>
public static class TagExtension
{
    #region Methods

    /// <summary>
    /// Prepares the tags asynchronous.
    /// </summary>
    /// <param name="tagIds">The tag ids.</param>
    /// <param name="tagRepository">The tag repository.</param>
    /// <returns></returns>
    public static async Task<IEnumerable<TagDto>> PrepareTagsAsync(
        this IEnumerable<Guid> tagIds, 
        ITagRepository tagRepository)
    {
        var tags = new List<TagDto>();
        if (tagIds != null && tagIds.Any())
        {
            var allTags = await tagRepository.GetAllAsync();
            if (allTags != null && allTags.Any())
            {
                foreach (var tagId in tagIds)
                {
                    var tag = allTags.FirstOrDefault(c => c.Id == tagId);
                    if (tag != null)
                    {
                        tags.Add(new TagDto
                        {
                            Id = tag.Id,
                            Name = tag.Name
                        });
                    }
                }
            }
        }

        return await Task.FromResult(tags);
    }

    #endregion
}
