using MyRecipes.Application.Dtos;
using MyRecipes.Domain.Repositories;
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
    public static async Task<List<TagDto>> PrepareTagsAsync(
        this List<Guid> tagIds, 
        ITagRepository tagRepository)
    {
        var tags = new List<TagDto>();
        if (tagIds != null && tagIds.Any())
        {
            var allTags = await tagRepository.GetAllAsync(null);
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
