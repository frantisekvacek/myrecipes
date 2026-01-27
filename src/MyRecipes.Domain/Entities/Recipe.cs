using System;
using System.Collections.Generic;

namespace MyRecipes.Domain.Entities;

/// <summary>
/// Recipe entity
/// </summary>
/// <seealso cref="BaseEntity" />
public sealed class Recipe : BaseEntity
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
    public IEnumerable<Guid> Tags { get; set; } = [];

    /// <summary>
    /// Gets or sets the categories.
    /// </summary>
    /// <value>
    /// The categories.
    /// </value>
    public IEnumerable<Guid> Categories { get; set; } = [];

    #endregion
}
