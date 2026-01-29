using FluentValidation;

namespace MyRecipes.Application.Features.Commands.Tags.CreateTag;

/// <summary>
/// Create tag command validator
/// </summary>
/// <seealso cref="AbstractValidator{CreateTagCommand}" />
public sealed class CreateTagCommandValidator : AbstractValidator<CreateTagCommand>
{
    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateTagCommandValidator"/> class.
    /// </summary>
    public CreateTagCommandValidator()
    {
        this.RuleFor(r => r.Dto.Name)
            .NotEmpty();
    }

    #endregion
}

