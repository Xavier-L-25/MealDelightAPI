using MealDelightAPI.Data;
using MealDelightAPI.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MealDelightAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public RecipeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Recipe>>> GetAllRecipes([FromQuery] string? query)
        {
            List<Recipe> recipes;

            if (query is null)
            {
                recipes = await _dataContext.Recipes.ToListAsync();
            }
            else
            {
                recipes = await _dataContext.Recipes
                                    .Where(r => r.Name.Contains(query))
                                    .ToListAsync();
            }
           

            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetRecipeById(int id)
        {
            var recipe = await _dataContext.Recipes.FindAsync(id);

            if (recipe is null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }
    }
}
