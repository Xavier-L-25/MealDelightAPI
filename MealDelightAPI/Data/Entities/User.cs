namespace MealDelightAPI.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string ImageUrl { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
