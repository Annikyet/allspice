using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using allspice.Models;


namespace allspice.Repositories
{
  public class RecipesRepository
  {
  //  public class BurgersRepository : IRepo<Burger>
  //  no extensions if i don't use interfaces

      private readonly IDbConnection _db;
      public RecipesRepository(IDbConnection db)
      {
          _db = db;
      }

      public Recipe Create(Recipe recipeData)
      {
        string sql = @"
        INSERT INTO recipes
          (creatorId, title, subtitle, category, picture)
        VALUES
          (@CreatorId, @Title, @Subtitle, @Category, @Picture);
        SELECT LAST_INSERT_ID();
        ";

        int id = _db.ExecuteScalar<int>(sql, recipeData);
        recipeData.Id = id;
        return recipeData;
      }

      public List<Recipe> GetAll()
      {
        string sql = @"
        SELECT
          a.*,
          r.*
        FROM recipes r
        JOIN accounts a
          ON a.id = r.creatorId;";
        return _db.Query<Profile, Recipe, Recipe>(sql, (prof, reci) =>
        {
          reci.Creator = prof;
          return reci;
        }).ToList();
      }

      public Recipe GetById(int id)
      {
        string sql = @"
        SELECT
          a.*,
          r.*
        FROM recipes r
        JOIN accounts a
          ON a.id = r.creatorId
        WHERE r.id = @id;";
        return _db.Query<Profile, Recipe, Recipe>(sql, (prof, reci) =>
        {
          reci.Creator = prof;
          return reci;
        }, new { id }).FirstOrDefault();
      }
  }
}