﻿using System.ComponentModel.DataAnnotations;

namespace MealDelightAPI.Models.User
{
    public class UserLoginDTO
    {
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
    }
}
