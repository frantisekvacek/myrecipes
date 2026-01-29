using FluentValidation;

namespace MyRecipes.Application.Features.Commands.Tags.UpdateTag;

/// <summary>
/// Update tag command validator
/// </summary>
/// <seealso cref="AbstractValidator{UpdateTagCommand}" />
public sealed class UpdateTagCommandValidator : AbstractValidator<UpdateTagCommand>
{
    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateTagCommandValidator"/> class.
    /// </summary>
    public UpdateTagCommandValidator()
    {
        this.RuleFor(r => r.Id)
            .NotNull();

        this.RuleFor(r => r.Dto.Name)
            .NotEmpty();
    }

    #endregion
}
