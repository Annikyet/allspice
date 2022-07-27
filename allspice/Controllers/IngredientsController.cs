using Microsoft.AspNetCore.Mvc;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using allspice.Models;
using allspice.Services;
using System.Collections.Generic;


namespace allspice.Models
{
  [ApiController]
  [Route("api/[controller]")]
  public class IngredientsController : ControllerBase
  {
    private readonly IngredientsService _is;
    private readonly RecipesService _rs;

    public IngredientsController(IngredientsService @is, RecipesService rs)
    {
      _is = @is;
      _rs = rs;
    }

    [HttpPost("{recipeId}")]
    [Authorize]
    public async Task<ActionResult<Ingredient>> Create(int recipeId, [FromBody] Ingredient ingredientData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        // override recipeId in data with URL id
        ingredientData.RecipeId = recipeId;
        Ingredient newIngredient = _is.Create(ingredientData, userInfo.Id);
        return Ok(newIngredient);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{recipeId}")]
    public ActionResult<List<Ingredient>> Get(int recipeId)
    {
      try
      {
        List<Ingredient> ingredients = _is.Get(recipeId);
        return Ok(ingredients);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}