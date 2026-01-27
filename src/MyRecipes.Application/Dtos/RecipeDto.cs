using System.Collections.Generic;

namespace MyRecipes.Application.Dtos;

/// <summary>
/// Recipe DTO
/// </summary>
/// <seealso cref="BaseDto" />
public sealed class RecipeDto : BaseDto
{
    #region Properties

    /// <summary>
    /// Gets or sets the title.
    /// </summary>
    /// <value>
    /// The title.
    /// </value>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the picture.
    /// </summary>
    /// <value>
    /// The picture.
    /// </value>
    public string Picture { get; set; }

    /// <summary>
    /// Gets or sets the ingredients.
    /// </summary>
    /// <value>
    /// The ingredients.
    /// </value>
    public string Ingredients { get; set; }

    /// <summary>
    /// Gets or sets the process.
    /// </summary>
    /// <value>
    /// The process.
    /// </value>
    public string Process { get; set; }

    /// <summary>
    /// Gets or sets the notes.
    /// </summary>
    /// <value>
    /// The notes.
    /// </value>
    public string Notes { get; set; }

    /// <summary>
    /// Gets or sets the preparation time.
    /// </summary>
    /// <value>
    /// The preparation time.
    /// </value>
    public int PreparationTime { get; set; }

    /// <summary>
    /// Gets or sets the number of servings.
    /// </summary>
    /// <value>
    /// The number of servings.
    /// </value>
    public int NumberOfServings { get; set; }

    /// <summary>
    /// Gets or sets the tags.
    /// </summary>
    /// <value>
    /// The tags.
    /// </value>
    public IEnumerable<TagDto> Tags { get; set; } = [];

    /// <summary>
    /// Gets or sets the categories.
    /// </summary>
    /// <value>
    /// The categories.
    /// </value>
    public IEnumerable<CategoryDto> Categories { get; set; } = [];

    #endregion
}
