using MyRecipes.Application.Commands.Base.BaseUpdate;
using MyRecipes.Application.Dtos;

namespace MyRecipes.Application.Commands.Tags.UpdateTag;

/// <summary>
/// Update tag command
/// </summary>
/// <seealso cref="BaseUpdateCommand{TagDto, TagDto}" />
public sealed class UpdateTagCommand : BaseUpdateCommand<TagDto, TagDto>
{
}
