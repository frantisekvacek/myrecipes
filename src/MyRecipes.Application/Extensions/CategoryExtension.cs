using MyRecipes.Application.Dtos;
using MyRecipes.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRecipes.Application.Extensions;

/// <summary>
/// Category extension
/// </summary>
public static class CategoryExtension
{
    #region Methods

    /// <summary>
    /// Prepares the categories asynchronous.
    /// </summary>
    /// <param name="categoryIds">The category ids.</param>
    /// <param name="categoryRepository">The category repository.</param>
    /// <returns></returns>
    public static async Task<List<CategoryDto>> PrepareCategoriesAsync(
        this List<Guid> categoryIds, 
        ICategoryRepository categoryRepository)
    {
        var categories = new List<CategoryDto>();
        if (categoryIds != null && categoryIds.Any())
        {
            var allCategories = await categoryRepository.GetAllAsync(null);
            if (allCategories != null && allCategories.Any())
            {
                foreach (var categoryId in categoryIds)
                {
                    var category = allCategories.FirstOrDefault(c => c.Id == categoryId);
                    if (category != null)
                    {
                        categories.Add(new CategoryDto
                        {
                            Id = category.Id,
                            Name = category.Name,
                            Picture = category.Picture,
                            Index = category.Index,
                            Visibility = category.Visibility,
                        });
                    }
                }
            }
        }

        return await Task.FromResult(categories);
    }

    #endregion
}
