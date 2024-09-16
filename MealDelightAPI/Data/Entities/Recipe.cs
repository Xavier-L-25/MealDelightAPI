using MealDelightAPI.Migrations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using IdentityUser = Microsoft.AspNetCore.Identity.IdentityUser;

namespace MealDelightAPI.Data.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public required string UserId { get; set; }
        public required string ImageUrl { get; set; }
        public required string Name { get; set; }
        public required string Type { get; set; }
        public required string Summary { get; set; }
        public required List<string> Ingredients { get; set; }
        public required string Instructions { get; set; }

        //Navigation Property to Users
        [JsonIgnore]
        public User? User { get; set; }
    }
}
