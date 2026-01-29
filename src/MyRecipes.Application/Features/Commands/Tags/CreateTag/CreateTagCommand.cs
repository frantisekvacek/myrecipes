using MyRecipes.Application.Dtos;
using MyRecipes.Application.Features.Commands.Base.BaseCreate;

namespace MyRecipes.Application.Features.Commands.Tags.CreateTag;

/// <summary>
/// Create tag command
/// </summary>
/// <seealso cref="BaseCreateCommand{TagDto, TagDto}" />
public sealed class CreateTagCommand : BaseCreateCommand<TagDto, TagDto>
{
}
