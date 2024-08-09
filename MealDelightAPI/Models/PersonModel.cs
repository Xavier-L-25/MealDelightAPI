using System.ComponentModel.DataAnnotations;

namespace MealDelightAPI.Models

{
    public class PersonModel
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
