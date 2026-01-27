using System;

namespace MyRecipes.Application.Dtos;

/// <summary>
/// Base DTO
/// </summary>
public abstract class BaseDto
{
    #region Properties

    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>
    /// The identifier.
    /// </value>
    public Guid Id { get; set; }

    #endregion
}
