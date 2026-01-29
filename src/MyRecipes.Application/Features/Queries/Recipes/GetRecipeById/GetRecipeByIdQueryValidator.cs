using FluentValidation;

namespace MyRecipes.Application.Features.Queries.Recipes.GetRecipeById;

/// <summary>
/// Get recipe by id query validator
/// </summary>
/// <seealso cref="AbstractValidator{GetRecipeByIdQuery}" />
public sealed class GetRecipeByIdQueryValidator : AbstractValidator<GetRecipeByIdQuery>
{
    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="GetRecipeByIdQueryValidator"/> class.
    /// </summary>
    public GetRecipeByIdQueryValidator()
    {
        this.RuleFor(r => r.Id)
            .NotNull();
    }

    #endregion
}
