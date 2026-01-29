using MyRecipes.Application.Commands.Base.BaseUpdate;
using MyRecipes.Application.Dtos;

namespace MyRecipes.Application.Commands.Categories.UpdateCategory;

/// <summary>
/// Update category command
/// </summary>
/// <seealso cref="BaseUpdateCommand{CategoryDto, CategoryDto}" />
public sealed class UpdateCategoryCommand : BaseUpdateCommand<CategoryDto, CategoryDto>
{
}
