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
  }
}