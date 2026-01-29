using Microsoft.Extensions.Logging;
using MyRecipes.Application.Dtos;
using MyRecipes.Application.Extensions;
using MyRecipes.Application.Features.Queries.Base.BaseGetById;
using MyRecipes.Application.Interfaces.Repositories;
using MyRecipes.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace MyRecipes.Application.Features.Queries.Recipes.GetRecipeById;

/// <summary>
/// Get recipe by id query handler
/// </summary>
/// <seealso cref="BaseGetByIdQueryHandler{GetRecipeByIdQuery, Recipe, RecipeDto}" />
public sealed class GetRecipeByIdQueryHandler : BaseGetByIdQueryHandler<GetRecipeByIdQuery, Recipe, RecipeDto>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ITagRepository _tagRepository;

    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="GetRecipeByIdQueryHandler" /> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="recipeRepository">The category repository.</param>
    /// <param name="categoryRepository">The category repository.</param>
    /// <param name="tagRepository">The tag repository.</param>
    /// <exception cref="ArgumentNullException">categoryRepository</exception>
    public GetRecipeByIdQueryHandler(
        ILogger<GetRecipeByIdQueryHandler> logger,
        IRecipeRepository recipeRepository,
        ICategoryRepository categoryRepository,
        ITagRepository tagRepository)
        : base(logger, recipeRepository)
    {
        this._categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        this._tagRepository = tagRepository ?? throw new ArgumentNullException(nameof(tagRepository));
    }

    #endregion

    #region Methods

    /// <summary>
    /// How entities are mapped to DTOs
    /// </summary>
    protected override async Task<RecipeDto> MapToDtoAsync(Recipe entity)
    {
        return entity != null
            ? new RecipeDto
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    Picture = entity.Picture,
                    Ingredients = entity.Ingredients,
                    Process = entity.Process,
                    Notes = entity.Notes,
                    PreparationTime = entity.PreparationTime,
                    NumberOfServings = entity.NumberOfServings,
                    Categories = await entity.Categories.PrepareCategoriesAsync(this._categoryRepository),
                    Tags = await entity.Tags.PrepareTagsAsync(this._tagRepository),
                }
            : null;
    }

    #endregion
}