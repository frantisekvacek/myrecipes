using FluentValidation;

namespace MyRecipes.Application.Features.Commands.Recipes.CreateRecipe;

/// <summary>
/// Create recipe command validator
/// </summary>
/// <seealso cref="AbstractValidator{CreateRecipeCommand}" />
public sealed class CreateRecipeCommandValidator : AbstractValidator<CreateRecipeCommand>
{
    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateRecipeCommandValidator"/> class.
    /// </summary>
    public CreateRecipeCommandValidator()
    {
        this.RuleFor(r => r.Dto.Title)
            .NotEmpty();

        this.RuleFor(r => r.Dto.PreparationTime)
            .NotNull();

        this.RuleFor(r => r.Dto.NumberOfServings)
            .NotNull();
    }

    #endregion
}
