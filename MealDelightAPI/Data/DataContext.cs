using MealDelightAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MealDelightAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Person> Person { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Recipe> Recipes { get; set; }

    }
}
