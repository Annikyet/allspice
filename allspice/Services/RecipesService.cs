using System.Collections.Generic;
using allspice.Models;
using allspice.Repositories;


namespace allspice.Services
{
  public class RecipesService
  {
    private readonly RecipesRepository _repo; // declares label for instance of repository
    public RecipesService(RecipesRepository repo) // import already instantiated persistent singleton of repository (C# framework voodoo)
    {
      _repo = repo;
    }

    internal Recipe Create(Recipe recipeData)
    {
      return _repo.Create(recipeData);
    }

    internal List<Recipe> Get() // method overloading
    {
      return _repo.GetAll();
    }

    internal Recipe Get(int id)
    {
      Recipe found = _repo.GetById(id);
      if (found == null)
      {
        throw new System.Exception("Invalid Id");
      }
      return found;
    }

    internal Recipe Update(Recipe update)
    {
      Recipe original = Get(update.Id);
      if (original == null)
      {
        throw new System.Exception("Invalid RecipeId");
      }
      if (original.CreatorID != update.CreatorID)
      {
        throw new System.Exception("Das Nacho Recipe!");
      }
      original.Picture = update.Picture ?? original.Picture;
      original.Title = update.Title ?? original.Title;
      original.Subtitle = update.Subtitle ?? original.Subtitle;
      original.Category = update.Category ?? original.Category;
      _repo.Update(original);
      return original;
    }
  }
}