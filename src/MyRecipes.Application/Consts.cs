using System;

namespace MyRecipes.Application;

/// <summary>
/// Constants
/// </summary>
public static class Consts
{
    #region DbContext

    public const string CSqlConnection = "SQLConnection";

    #endregion

    #region Entities

    // Categories
    public static readonly Guid CategoryMainCoursesId = Guid.Parse("ef34d609-1f2d-4863-ab67-1dc4dd822333");
    public static readonly string CategoryMainCourses = "Hlavné jedlá";

    public static readonly Guid CategorySoupsAndDishesId = Guid.Parse("05457a86-e2b0-4b5c-90d4-9fb657b10449");
    public static readonly string CategorySoupsAndDishes = "Polievky a prílohy";

    public static readonly Guid CategoryBreakfastAndDinnerId = Guid.Parse("ae3289c8-3ad3-48e8-9ed3-b3ece7be5c03");
    public static readonly string CategoryBreakfastAndDinner = "Raňajky a večere";

    public static readonly Guid CategorySweerAndSavoryId = Guid.Parse("ed101e92-c1d3-494e-824f-f208af796cfd");
    public static readonly string CategorySweerAndSavory = "Sladké a slané";

    public static readonly Guid CategoryHolidayDishesId = Guid.Parse("6d4ca1ca-bba5-45f3-890f-2ffcdf400bb8");
    public static readonly string CategoryHolidayDishes = "Sviatočné jedlá";

    public static readonly Guid CategoryAllRecipesId = Guid.Parse("77bd497a-9a8c-40e1-aec5-a03d82292e10");
    public static readonly string CategoryAllRecipes = "Všetky recepty";

    #endregion
}
