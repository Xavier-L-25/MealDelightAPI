using System.ComponentModel.DataAnnotations;

namespace MealDelightAPI.Models.User
{
    public class UserAddDTO
    {
        [Required]
        public required string FirstName { get; set; }
        [Required]
        public required string LastName { get; set; }
        [Required]
        public required string ImageUrl { get; set; }
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
    }
}
