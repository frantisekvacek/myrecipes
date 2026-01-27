using MyRecipes.Application.Dtos;

namespace MyRecipes.Application.CQRS.Commands.Tags;

/// <summary>
/// Update tag command
/// </summary>
/// <seealso cref="BaseUpdateCommand{TagDto, TagDto}" />
public sealed class UpdateTagCommand : BaseUpdateCommand<TagDto, TagDto>
{
}
