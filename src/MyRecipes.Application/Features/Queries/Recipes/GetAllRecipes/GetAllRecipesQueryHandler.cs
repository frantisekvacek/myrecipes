using Microsoft.Extensions.Logging;
using MyRecipes.Application.Dtos;
using MyRecipes.Application.Extensions;
using MyRecipes.Application.Features.Queries.Base.BaseGetAll;
using MyRecipes.Domain.Entities;
using MyRecipes.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRecipes.Application.Features.Queries.Recipes.GetAllRecipes;

/// <summary>
/// Get all recipes query handlers
/// </summary>
/// <seealso cref="BaseGetAllQueryHandler{GetAllRecipesQuery, Recipe, RecipeDto}" />
public sealed class GetAllRecipesQueryHandler : BaseGetAllQueryHandler<GetAllRecipesQuery, Recipe, RecipeDto>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ITagRepository _tagRepository;

    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="GetAllRecipesQueryHandler" /> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="recipeRepository">The category repository.</param>
    /// <param name="categoryRepository">The category repository.</param>
    /// <param name="tagRepository">The tag repository.</param>
    /// <exception cref="ArgumentNullException">categoryRepository</exception>
    public GetAllRecipesQueryHandler(
        ILogger<GetAllRecipesQueryHandler> logger,
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
    protected override async Task<IEnumerable<RecipeDto>> MapToDtosAsync(IEnumerable<Recipe> entities)
    {
        return await Task.WhenAll(entities?.Select(async recipe => new RecipeDto
        {
            Id = recipe.Id,
            Title = recipe.Title,
            Picture = recipe.Picture,
            Ingredients = recipe.Ingredients,
            Process = recipe.Process,
            Notes = recipe.Notes,
            PreparationTime = recipe.PreparationTime,
            NumberOfServings = recipe.NumberOfServings,
            Categories = await recipe.Categories.PrepareCategoriesAsync(this._categoryRepository),
            Tags = await recipe.Tags.PrepareTagsAsync(this._tagRepository),
        }));
    }

    #endregion
}