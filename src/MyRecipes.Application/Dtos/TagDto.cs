namespace MyRecipes.Application.Dtos;

/// <summary>
/// Tag DTO
/// </summary>
/// <seealso cref="BaseDto" />
public sealed class TagDto : BaseDto
{
    #region Properties

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>
    /// The name.
    /// </value>
    public string Name { get; set; }

    #endregion
}
