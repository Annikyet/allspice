using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using allspice.Models;
using allspice.Controllers;
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
  }
}