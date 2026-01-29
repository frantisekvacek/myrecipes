using System;
using System.Collections.Generic;
using System.Text;

namespace MyRecipes.Application.Dtos;

/// <summary>
/// 
/// </summary>
public sealed class ProblemDetailDto
{
    #region Properties

    /// <summary>
    /// Gets the type.
    /// </summary>
    /// <value>
    /// The type.
    /// </value>
    public string Type { get; init; }

    /// <summary>
    /// Gets the title.
    /// </summary>
    /// <value>
    /// The title.
    /// </value>
    public string Title { get; init; }

    /// <summary>
    /// Gets the status.
    /// </summary>
    /// <value>
    /// The status.
    /// </value>
    public int Status { get; init; }

    /// <summary>
    /// Gets the detail.
    /// </summary>
    /// <value>
    /// The detail.
    /// </value>
    public string Detail { get; init; }

    /// <summary>
    /// Gets the errors.
    /// </summary>
    /// <value>
    /// The errors.
    /// </value>
    public IDictionary<string, string[]> Errors { get; init; } = new Dictionary<string, string[]>();

    #endregion
}
