using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using allspice.Models;
using allspice.Services;
using allspice.Controllers;


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
  }
}