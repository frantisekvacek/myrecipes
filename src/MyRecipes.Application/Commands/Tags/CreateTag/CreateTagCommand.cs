using MyRecipes.Application.Commands.Base.BaseCreate;
using MyRecipes.Application.Dtos;

namespace MyRecipes.Application.Commands.Tags.CreateTag;

/// <summary>
/// Create tag command
/// </summary>
/// <seealso cref="BaseCreateCommand{TagDto, TagDto}" />
public sealed class CreateTagCommand : BaseCreateCommand<TagDto, TagDto>
{
}
