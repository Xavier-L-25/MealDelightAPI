using System.ComponentModel.DataAnnotations;

namespace MealDelightAPI.Models.Recipe
{
    public class RecipeUpdateDTO : RecipeAddDTO
    {
        [Required]
        public required int Id { get; set; }
    }
}
