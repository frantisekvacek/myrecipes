using System;
using System.Collections.Generic;

namespace MyRecipes.Application.Exceptions;

/// <summary>
/// Validations exception
/// </summary>
/// <seealso cref="System.Exception" />
public sealed class ValidationsException : Exception
{
    public IDictionary<string, string[]> Errors { get; }

    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationsException"/> class.
    /// </summary>
    /// <param name="errors">The errors.</param>
    public ValidationsException(IDictionary<string, string[]> errors)
        : base("Validation failed")
    {
        this.Errors = errors;
    }

    #endregion
}