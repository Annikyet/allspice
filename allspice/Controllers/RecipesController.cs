using Microsoft.AspNetCore.Mvc;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using allspice.Models;
using allspice.Services;
using allspice.Repositories;

namespace allspice.Controllers
{ // should this be brackets???
[ApiController] // flags for .net to register as a controller
[Route("api/[controller]")] // establish endpoint url based on class name (strips 'Controller' from name)
public class RecipesController : ControllerBase
{
    private readonly RecipesService _rs;  // doesn't instantiate, just creates field (not property because it doesn't have get set)
    public RecipesController(RecipesService rs)
    {
        _rs = rs;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Recipe>> Create([FromBody] Recipe recipeData)
    {
        try
        {
            Account userInfo = await HttpContext.GetUserInfoAsync<Account>();   // get signed in user's account
            recipeData.CreatorID = userInfo.Id; // override CreatorId to signed in user's
            Recipe newRecipe = _rs.Create(recipeData); // call service to create recipe in db
            return Ok(newRecipe); // return HTTP 200, with the new recipe - possibly faster to only pass 200?
        }
        catch (System.Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
}
}