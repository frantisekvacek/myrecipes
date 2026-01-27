using Microsoft.EntityFrameworkCore;
using MyRecipes.Application.Extensions;
using MyRecipes.Persistence.Context;
using MyRecipes.Persistence.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Serilog logging
builder.Host.UseSerilog((context, services, configuration) =>
{
    configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services);
});

// =============================================
// Services
// =============================================

// Controllers
builder.Services.AddControllers();

// Swagger / Open API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Application & Persistence
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);

// =============================================
// Build app
// =============================================

var app = builder.Build();

// Request logging
app.UseSerilogRequestLogging();

// DB migrations
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MyRecipeDbContext>();
    dbContext.Database.Migrate(); // vytvorí DB + aplikuje všetky migrácie
}

// =============================================
// Middleware pipeline
// =============================================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();