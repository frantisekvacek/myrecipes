using Microsoft.Extensions.Logging;
using MyRecipes.Application.CQRS.Commands.Tags;
using MyRecipes.Application.CQRS.Interfaces;
using MyRecipes.Application.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace MyRecipes.Application.CQRS.Handlers.Tags;

/// <summary>
/// Delete tag command handler
/// </summary>
/// <seealso cref="IRequestHandler{DeleteTagCommand, bool}" />
public sealed class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, bool>
{
    private readonly ILogger<DeleteTagCommandHandler> _logger;
    private readonly ITagRepository _tagRepository;

    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteTagCommandHandler" /> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="tagRepository">The tag repository.</param>
    /// <exception cref="ArgumentNullException">tagRepository</exception>
    public DeleteTagCommandHandler(
        ILogger<DeleteTagCommandHandler> logger, 
        ITagRepository tagRepository)
    {
        this._logger = logger
            ?? throw new ArgumentNullException(nameof(logger));
        this._tagRepository = tagRepository 
            ?? throw new ArgumentNullException(nameof(tagRepository));
    }

    #endregion

    #region Methods

    /// <summary>
    /// Handles the specified command.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <returns></returns>
    public async Task<bool> Handle(DeleteTagCommand command)
    {
        var existingTab = await this._tagRepository.GetByIdAsync(command.Id);
        if (existingTab != null)
        {
            this._logger.LogInformation("Delete tag with id: {id}", command.Id);
            await this._tagRepository.DeleteAsync(command.Id);
            return true;
        }
        return false;
    }

    #endregion
}
