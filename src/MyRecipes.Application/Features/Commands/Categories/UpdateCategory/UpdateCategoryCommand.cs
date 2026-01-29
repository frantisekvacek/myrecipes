using MyRecipes.Application.Dtos;
using MyRecipes.Application.Features.Commands.Base.BaseUpdate;

namespace MyRecipes.Application.Features.Commands.Categories.UpdateCategory;

/// <summary>
/// Update category command
/// </summary>
/// <seealso cref="BaseUpdateCommand{CategoryDto, CategoryDto}" />
public sealed class UpdateCategoryCommand : BaseUpdateCommand<CategoryDto, CategoryDto>
{
}
