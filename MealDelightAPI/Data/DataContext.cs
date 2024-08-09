using MealDelightAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MealDelightAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<SuperHero> MyProperty { get; set; }
        public DbSet<Person> Person { get; set; }
    }
}
