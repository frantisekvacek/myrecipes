using Microsoft.Extensions.Logging;
using MyRecipes.Application.CQRS.Interfaces;
using MyRecipes.Application.CQRS.Queries.Recipes;
using MyRecipes.Application.Dtos;
using MyRecipes.Application.Extensions;
using MyRecipes.Application.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace MyRecipes.Application.CQRS.Handlers.Recipes;

/// <summary>
/// Get recipe by id query handler
/// </summary>
/// <seealso cref="IRequestHandler{GetRecipeByIdQuery, RecipeDto}" />
public sealed class GetRecipeByIdQueryHandler : IRequestHandler<GetRecipeByIdQuery, RecipeDto>
{
    private readonly ILogger<GetRecipeByIdQueryHandler> _logger;
    private readonly IRecipeRepository _recipeRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly ITagRepository _tagRepository;

    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="GetRecipeByIdQueryHandler" /> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="recipeRepository">The recipe repository.</param>
    /// <param name="categoryRepository">The category repository.</param>
    /// <param name="tagRepository">The tag repository.</param>
    /// <exception cref="ArgumentNullException">recipeRepository</exception>
    public GetRecipeByIdQueryHandler(
        ILogger<GetRecipeByIdQueryHandler> logger,
        IRecipeRepository recipeRepository,
        ICategoryRepository categoryRepository,
        ITagRepository tagRepository)
    {
        this._logger = logger
            ?? throw new ArgumentNullException(nameof(logger));
        this._recipeRepository = recipeRepository 
            ?? throw new ArgumentNullException(nameof(recipeRepository));
        this._categoryRepository = categoryRepository 
            ?? throw new ArgumentNullException(nameof(categoryRepository));
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
    public async Task<RecipeDto> Handle(GetRecipeByIdQuery query)
    {
        var recipe = await this._recipeRepository.GetByIdAsync(query.Id);
        if (recipe != null)
        {
            this._logger.LogInformation("Get recipe with id: {id}", query.Id);
            return new RecipeDto
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
            };
        }

        return null;
    }

    #endregion
}
