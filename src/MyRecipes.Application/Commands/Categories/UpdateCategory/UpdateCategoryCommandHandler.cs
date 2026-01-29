using Microsoft.Extensions.Logging;
using MyRecipes.Application.Commands.Base.BaseUpdate;
using MyRecipes.Application.Dtos;
using MyRecipes.Application.Interfaces.Repositories;
using MyRecipes.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace MyRecipes.Application.Commands.Categories.UpdateCategory;

/// <summary>
/// Update category command handler
/// </summary>
/// <seealso cref="BaseUpdateCommandHandler{UpdateCategoryCommand, Category, CategoryDto}" />
public sealed class UpdateCategoryCommandHandler : BaseUpdateCommandHandler<UpdateCategoryCommand, Category, CategoryDto>
{
    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateCategoryCommandHandler" /> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="categoryRepository">The category repository.</param>
    /// <exception cref="ArgumentNullException">categoryRepository</exception>
    public UpdateCategoryCommandHandler(
        ILogger<UpdateCategoryCommandHandler> logger,
        ICategoryRepository categoryRepository)
        : base(logger, categoryRepository)
    {
    }

    #endregion

    #region Methods

    /// <summary>
    /// Maps to entity asynchronous.
    /// </summary>
    /// <param name="existingEntity">The existing entity.</param>
    /// <param name="dto">The dto.</param>
    protected override async Task MapToEntityAsync(Category existingEntity, CategoryDto dto)
    {
        existingEntity.Name = dto.Name;
        existingEntity.Picture = dto.Picture;
        existingEntity.Index = dto.Index;
        existingEntity.Visibility = dto.Visibility;
    }

    #endregion
}