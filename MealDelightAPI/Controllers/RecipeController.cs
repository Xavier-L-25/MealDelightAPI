using MealDelightAPI.Data;
using MealDelightAPI.Data.Entities;
using MealDelightAPI.Models.Recipe;
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

        [HttpPost]
        public async Task<ActionResult<Recipe>> AddRecipe([FromBody] RecipeAddDTO model)
        {
            try
            {
                var recipeModel = new Recipe
                {
                    UserId = model.UserId,
                    ImageUrl = model.ImageUrl,
                    Name = model.Name,
                    Type = model.Type,
                    Summary = model.Summary,
                    Ingredients = model.Ingredients,
                    Instructions = model.Instructions,
                };

                _dataContext.Recipes.Add(recipeModel);
                await _dataContext.SaveChangesAsync();

                return Ok(recipeModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Recipe>> UpdateRecipe([FromBody] RecipeUpdateDTO model)
        {
            try
            {
                var recipeModel = new Recipe
                {
                    Id = model.Id,
                    UserId = model.UserId,
                    ImageUrl = model.ImageUrl,
                    Name = model.Name,
                    Type = model.Type,
                    Summary = model.Summary,
                    Ingredients = model.Ingredients,
                    Instructions = model.Instructions,
                };

                _dataContext.Recipes.Add(recipeModel);
                await _dataContext.SaveChangesAsync();

                return Ok(recipeModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Recipe>> DeleteRecipe(int id)
        {
            try
            {
                var recipe = await _dataContext.Recipes.FindAsync(id);

                if (recipe is null) return NotFound("Recipe doesn't exist");

                _dataContext.Recipes.Remove(recipe);
                await _dataContext.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
