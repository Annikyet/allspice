using System.Collections.Generic;
using allspice.Models;
using allspice.Repositories;


namespace allspice.Services
{
  public class IngredientsService
  {
    private readonly IngredientsRepository _repo;
    private readonly RecipesService _rs;
    public IngredientsService(IngredientsRepository repo, RecipesService rs)
    {
      _repo = repo;
      _rs = rs;
    }

    internal Ingredient Create(Ingredient ingredientData, string userId)
    {
        // check that the ingredient's recipe is owned by the logged in user
      Recipe recipeData = _rs.Get(ingredientData.RecipeId);
      if (recipeData == null)
      {
        throw new System.Exception("Invalid RecipeId");
      }
      if (recipeData.CreatorID != userId)
      {
        throw new System.Exception("Das Nacho Recipe!");
      }
      // now actually create the ingredient
      return _repo.Create(ingredientData);
    }

    internal List<Ingredient> Get(int recipeId)
    {
      return _repo.GetByRecipe(recipeId);
      
    }
  }
}