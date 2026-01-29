using FluentValidation;

namespace MyRecipes.Application.Features.Commands.Categories.UpdateCategory;

/// <summary>
/// Update category command validator
/// </summary>
/// <seealso cref="AbstractValidator{UpdateCategoryCommand}" />
public sealed class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateCategoryCommandValidator"/> class.
    /// </summary>
    public UpdateCategoryCommandValidator()
    {
        this.RuleFor(r => r.Id)
            .NotNull();

        this.RuleFor(r => r.Dto.Name)
            .NotEmpty();

        this.RuleFor(r => r.Dto.Visibility)
            .NotNull();
    }

    #endregion
}
