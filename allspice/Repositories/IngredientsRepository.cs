using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using allspice.Models;

// does ; or {} matter for namespace?
namespace allspice.Repositories
{
  public class IngredientsRepository
  {
    private readonly IDbConnection _db;
    public IngredientsRepository(IDbConnection db)
    {
        _db = db;
    }

    public Ingredient Create(Ingredient ingredientData)
    {
      string sql = @"
      INSERT INTO ingredients
      (name, quantity, recipeId)
      VALUES
      (@Name, @Quantity, @RecipeId);
      ";
      _db.ExecuteScalar(sql, ingredientData);
      return ingredientData;
    }

    public List<Ingredient> GetByRecipe(int recipeId)
    {
      string sql = @"
      SELECT
        i.*
      FROM ingredients i
      WHERE i.recipeId = @recipeId
      ";
      List<Ingredient> ingredients = _db.Query<Ingredient>(sql, new{recipeId}).ToList();
      return ingredients;
    }
  }
}

        // return _db.Query<Profile, Recipe, Recipe>(sql, (prof, reci) =>
        // {
        //   reci.Creator = prof;
        //   return reci;
        // }).ToList();