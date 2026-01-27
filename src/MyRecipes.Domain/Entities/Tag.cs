namespace MyRecipes.Domain.Entities;

/// <summary>
/// Tag entity
/// </summary>
/// <seealso cref="BaseEntity" />
public sealed class Tag : BaseEntity
{
    #region Properties

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>
    /// The name.
    /// </value>
    public string Name { get; set; } = string.Empty;

    #endregion
}
