using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MealDelightAPI.Data.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public required int UserId { get; set; }
        public required string ImageUrl { get; set; }

        [Range(1, 100, ErrorMessage = "Recipe name must be between 1 and 100 characters")]
        public required string Name { get; set; }
        public required string Type { get; set; }
        public required string Description { get; set; }

        //Navigation Property to Users
        [JsonIgnore]
        public User? Users { get; set; }
    }
}
