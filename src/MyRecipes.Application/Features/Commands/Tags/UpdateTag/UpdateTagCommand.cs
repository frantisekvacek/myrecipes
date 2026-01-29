using MyRecipes.Application.Dtos;
using MyRecipes.Application.Features.Commands.Base.BaseUpdate;

namespace MyRecipes.Application.Features.Commands.Tags.UpdateTag;

/// <summary>
/// Update tag command
/// </summary>
/// <seealso cref="BaseUpdateCommand{TagDto, TagDto}" />
public sealed class UpdateTagCommand : BaseUpdateCommand<TagDto, TagDto>
{
}
