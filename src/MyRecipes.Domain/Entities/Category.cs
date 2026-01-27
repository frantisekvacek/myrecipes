namespace MyRecipes.Domain.Entities;

/// <summary>
/// Category entity
/// </summary>
/// <seealso cref="BaseEntity" />
public sealed class Category : BaseEntity
{
    #region Properties

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>
    /// The name.
    /// </value>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the picture.
    /// </summary>
    /// <value>
    /// The picture.
    /// </value>
    public string Picture { get; set; }

    /// <summary>
    /// Gets or sets the index.
    /// </summary>
    /// <value>
    /// The index.
    /// </value>
    public int Index { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="Category"/> is visibility.
    /// </summary>
    /// <value>
    ///   <c>true</c> if visibility; otherwise, <c>false</c>.
    /// </value>
    public bool Visibility { get; set; }

    #endregion
}
