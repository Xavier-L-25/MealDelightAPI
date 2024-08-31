﻿using MealDelightAPI.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MealDelightAPI.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
       
        public DbSet<Recipe> Recipes { get; set; }

        //public DbSet<User> Users { get; set; }
        //public DbSet<UserCredential> UserCredentials { get; set; }
    }
}
