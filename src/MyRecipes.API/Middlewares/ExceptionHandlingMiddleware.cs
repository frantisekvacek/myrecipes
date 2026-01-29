using MyRecipes.Application.Dtos;
using MyRecipes.Application.Exceptions;
using System.Text.Json;

namespace MyRecipes.API.Middlewares;

public sealed class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="ExceptionHandlingMiddleware"/> class.
    /// </summary>
    /// <param name="next">The next.</param>
    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        this._next = next;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Invokes the specified context.
    /// </summary>
    /// <param name="context">The context.</param>
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await this._next(context);
        }
        catch (ValidationsException ex)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/json";

            var problem = new ProblemDetailDto
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Status = 400,
                Title = "Validation error",
                Detail = "One or more validation errors occurred.",
                Errors = ex.Errors
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(problem));
        }
    }

    #endregion
}
