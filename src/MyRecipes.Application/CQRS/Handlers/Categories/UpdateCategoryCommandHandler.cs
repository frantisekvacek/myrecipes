using Microsoft.Extensions.Logging;
using MyRecipes.Application.CQRS.Commands.Categories;
using MyRecipes.Application.CQRS.Interfaces;
using MyRecipes.Application.Dtos;
using MyRecipes.Application.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace MyRecipes.Application.CQRS.Handlers.Categories;

/// <summary>
/// Update category command handler
/// </summary>
/// <seealso cref="IRequestHandler{UpdateCategoryCommand, CategoryDto}" />
public sealed class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryDto>
{
    private readonly ILogger<UpdateCategoryCommandHandler> _logger;
    private readonly ICategoryRepository _categoryRepository;

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
    {
        this._logger = logger 
            ?? throw new ArgumentNullException(nameof(logger));
        this._categoryRepository = categoryRepository 
            ?? throw new ArgumentNullException(nameof(categoryRepository));
    }

    #endregion

    #region Methods

    /// <summary>
    /// Handles the specified command.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <returns></returns>
    public async Task<CategoryDto> Handle(UpdateCategoryCommand command)
    {
        this._logger.LogInformation("Update category with id: {id}", command.Id);
        var existingCategory = await this._categoryRepository.GetByIdAsync(command.Id);
        if (existingCategory != null)
        {
            existingCategory.Name = command.Dto.Name;
            existingCategory.Picture = command.Dto.Picture;
            existingCategory.Index = command.Dto.Index;
            existingCategory.Visibility = command.Dto.Visibility;

            await this._categoryRepository.UpdateAsync(existingCategory);
            command.Dto.Id = command.Id;
            return command.Dto;
        }
        return null;
    }

    #endregion
}
