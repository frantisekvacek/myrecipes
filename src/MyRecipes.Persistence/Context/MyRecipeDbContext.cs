using Microsoft.EntityFrameworkCore;
using MyRecipes.Application;
using MyRecipes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace MyRecipes.Persistence.Context;

/// <summary>
/// My recipe DB context
/// </summary>
/// <seealso cref="DbContext" />
public class MyRecipeDbContext : DbContext
{
    private const string CVarcharMax = "nvarchar(max)";

    #region C'tor

    /// <summary>
    /// Initializes a new instance of the <see cref="MyRecipeDbContext"/> class.
    /// </summary>
    /// <param name="options">The options.</param>
    public MyRecipeDbContext(DbContextOptions<MyRecipeDbContext> options) 
        : base(options)
    {
    }

    #endregion

    #region DbSets

    /// <summary>
    /// Gets the tags.
    /// </summary>
    /// <value>
    /// The tags.
    /// </value>
    public DbSet<Tag> Tags => this.Set<Tag>();

    /// <summary>
    /// Gets the categories.
    /// </summary>
    /// <value>
    /// The categories.
    /// </value>
    public DbSet<Category> Categories => this.Set<Category>();

    /// <summary>
    /// Gets the recipes.
    /// </summary>
    /// <value>
    /// The recipes.
    /// </value>
    public DbSet<Recipe> Recipes => this.Set<Recipe>();

    #endregion

    #region Methods

    /// <summary>
    /// Override this method to further configure the model that was discovered by convention from the entity types
    /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
    /// and re-used for subsequent instances of your derived context.
    /// </summary>
    /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
    /// define extension methods on this object that allow you to configure aspects of the model that are specific
    /// to a given database.</param>
    /// <remarks>
    /// <para>
    /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
    /// then this method will not be run. However, it will still run when creating a compiled model.
    /// </para>
    /// <para>
    /// See <see href="https://aka.ms/efcore-docs-modeling">Modeling entity types and relationships</see> for more information and
    /// examples.
    /// </para>
    /// </remarks>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Category builder
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable(nameof(Category));

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Name)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(x => x.Picture)
                  .HasColumnType(CVarcharMax);

            entity.Property(x => x.Visibility)
                  .IsRequired();

            entity.Property(x => x.Index)
                  .IsRequired();

            entity.HasData(
                new Category
                {
                    Id = Consts.CategoryMainCoursesId,
                    Name = Consts.CategoryMainCourses,
                    Picture = "",
                    Index = 0,
                    Visibility = true
                },
                new Category
                {
                    Id = Consts.CategorySoupsAndDishesId,
                    Name = Consts.CategorySoupsAndDishes,
                    Picture = "",
                    Index = 1,
                    Visibility = true
                },
                new Category
                {
                    Id = Consts.CategoryBreakfastAndDinnerId,
                    Name = Consts.CategoryBreakfastAndDinner,
                    Picture = "",
                    Index = 2,
                    Visibility = true
                },
                new Category
                {
                    Id = Consts.CategorySweerAndSavoryId,
                    Name = Consts.CategorySweerAndSavory,
                    Picture = "",
                    Index = 3,
                    Visibility = true
                },
                new Category
                {
                    Id = Consts.CategoryHolidayDishesId,
                    Name = Consts.CategoryHolidayDishes,
                    Picture = "",
                    Index = 4,
                    Visibility = true
                },
                new Category
                {
                    Id = Consts.CategoryAllRecipesId,
                    Name = Consts.CategoryAllRecipes,
                    Picture = "",
                    Index = 5,
                    Visibility = true
                }
            );
        });

        // Recipe builder
        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.ToTable(nameof(Recipe));

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Title)
                  .IsRequired()
                  .HasMaxLength(250);

            entity.Property(x => x.Picture)
                  .HasColumnType(CVarcharMax);

            entity.Property(x => x.PreparationTime)
                  .IsRequired();

            entity.Property(x => x.NumberOfServings)
                  .IsRequired();

            entity.Property(x => x.Tags)
                  .HasConversion(
                        v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                        v => JsonSerializer.Deserialize<List<Guid>>(v, (JsonSerializerOptions)null) ?? new List<Guid>())
                  .HasColumnType(CVarcharMax);

            entity.Property(x => x.Categories)
                  .HasConversion(
                       v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                       v => JsonSerializer.Deserialize<List<Guid>>(v, (JsonSerializerOptions)null) ?? new List<Guid>())
                  .HasColumnType(CVarcharMax);
        });

        // Tag builder
        modelBuilder.Entity<Tag>(entity =>
        {
            entity.ToTable(nameof(Tag));

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Name)
                  .IsRequired()
                  .HasMaxLength(100);
        });

        base.OnModelCreating(modelBuilder);
    }

    #endregion
}
