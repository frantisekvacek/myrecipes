using FluentValidation;
using MyRecipes.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRecipes.Application.Features.Base;

/// <summary>
/// Validation behavior
/// </summary>
/// <typeparam name="TRequest">The type of the request.</typeparam>
/// <typeparam name="TResponse">The type of the response.</typeparam>
/// <seealso cref="IPipelineBehavior&lt;TRequest, TResponse&gt;" />
public sealed class ValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationBehavior{TRequest, TResponse}"/> class.
    /// </summary>
    /// <param name="validators">The validators.</param>
    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        this._validators = validators;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Handles the specified request.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="next">The next.</param>
    /// <returns></returns>
    /// <exception cref="ValidationsException"></exception>
    public async Task<TResponse> Handle(TRequest request, Func<Task<TResponse>> next)
    {
        if (this._validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(
                this._validators.Select(v => v.ValidateAsync(context))
            );

            var failures = validationResults
                .SelectMany(r => r.Errors)
                .Where(f => f != null)
                .GroupBy(
                    e => e.PropertyName,
                    e => e.ErrorMessage)
                .ToDictionary(
                    g => g.Key,
                    g => g.ToArray());

            if (failures.Count != 0)
            {
                throw new ValidationsException(failures);
            }
        }

        return await next();
    }

    #endregion
}
