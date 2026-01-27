using MyRecipes.Application.CQRS.Commands.Base;
using MyRecipes.Application.Dtos;

namespace MyRecipes.Application.CQRS.Commands.Tags;

/// <summary>
/// Create tag command
/// </summary>
/// <seealso cref="BaseCreateCommand{TagDto, TagDto}" />
public sealed class CreateTagCommand : BaseCreateCommand<TagDto, TagDto>
{
}
