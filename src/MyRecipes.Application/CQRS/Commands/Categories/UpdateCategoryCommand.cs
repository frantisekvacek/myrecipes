using MyRecipes.Application.CQRS.Commands.Base;
using MyRecipes.Application.Dtos;

namespace MyRecipes.Application.CQRS.Commands.Categories;

/// <summary>
/// Update category command
/// </summary>
/// <seealso cref="BaseUpdateCommand{CategoryDto, CategoryDto}" />
public sealed class UpdateCategoryCommand : BaseUpdateCommand<CategoryDto, CategoryDto>
{
}
