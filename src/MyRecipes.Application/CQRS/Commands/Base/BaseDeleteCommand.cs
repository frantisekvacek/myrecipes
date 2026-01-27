using MyRecipes.Application.CQRS.Interfaces;
using System;

namespace MyRecipes.Application.CQRS.Commands.Base;

/// <summary>
/// Base delete command
/// </summary>
/// <seealso cref="IRequest{bool} />
public abstract class BaseDeleteCommand : IRequest<bool>
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
