﻿//using Microsoft.EntityFrameworkCore;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Text.Json.Serialization;

//namespace MealDelightAPI.Data.Entities
//{
//    [PrimaryKey(nameof(UserId), nameof(Email))] 
//    public class UserCredential
//    {
//        [ForeignKey("User")]
//        public int UserId { get; set; }
//        public required string Email { get; set; }
//        public required string Password { get; set; }

//        //Navigation Property to Users
//        [JsonIgnore]
//        public User? User { get; set; }
//    }
//}
