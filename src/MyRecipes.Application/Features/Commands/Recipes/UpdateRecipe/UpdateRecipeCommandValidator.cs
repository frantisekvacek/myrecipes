using FluentValidation;

namespace MyRecipes.Application.Features.Commands.Recipes.UpdateRecipe;

/// <summary>
/// Update recipe command validator
/// </summary>
/// <seealso cref="AbstractValidator{UpdateRecipeCommand}" />
public sealed class UpdateRecipeCommandValidator : AbstractValidator<UpdateRecipeCommand>
{
    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateRecipeCommandValidator"/> class.
    /// </summary>
    public UpdateRecipeCommandValidator()
    {
        this.RuleFor(r => r.Id)
            .NotNull();

        this.RuleFor(r => r.Dto.Title)
            .NotEmpty();

        this.RuleFor(r => r.Dto.PreparationTime)
            .NotNull();

        this.RuleFor(r => r.Dto.NumberOfServings)
            .NotNull();
    }

    #endregion
}
