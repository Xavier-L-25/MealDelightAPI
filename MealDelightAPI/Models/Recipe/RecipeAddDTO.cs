using System.ComponentModel.DataAnnotations;

namespace MealDelightAPI.Models.Recipe
{
    public class RecipeAddDTO
    {
        [Required]
        public required string UserId { get; set; }
        
        [Required]
        public required string ImageUrl { get; set; }
        
        [Required]
        //[Range(1, 100, ErrorMessage = "Recipe name must be between 1 and 100 characters")]
        public required string Name { get; set; }
        
        [Required]
        public required string Type { get; set; }

        [Required]
        public required string Summary { get; set; }

        [Required]
        public required List<string> Ingredients { get; set; }

        [Required]
        public required string Instructions { get; set; }
    }
}
