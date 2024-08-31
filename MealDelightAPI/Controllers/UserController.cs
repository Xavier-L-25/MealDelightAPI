//using MealDelightAPI.Data;
//using MealDelightAPI.Data.Entities;
//using MealDelightAPI.Models.User;
//using MealDelightAPI.Services;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Http.HttpResults;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace MealDelightAPI.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class UserController : ControllerBase
//    {
//        private readonly DataContext _dataContext;

//        public UserController(DataContext dataContext)
//        {
//            _dataContext = dataContext;
//        }

//        [HttpGet]
//        public async Task<ActionResult<List<User>>> GetAllUsers()
//        {
//            try
//            {
//                var users = await _dataContext.Users.ToListAsync();
//                return Ok(users);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<User>> GetUserById(int id)
//        {
//            try
//            {
//                var user = await _dataContext.Users.FindAsync(id);

//                if (user is null)
//                {
//                    return NotFound();
//                }

//                return Ok(user);
//            } 
//            catch (Exception ex) 
//            { 
//                return BadRequest(ex.Message); 
//            }
//        }

//        [HttpPost("register")]
//        public async Task<ActionResult<User>> AddUser([FromBody] UserAddDTO model)
//        {
//            bool emailCheck = await _dataContext.UserCredentials.AnyAsync(u => u.Email == model.Email);

//            if (emailCheck)
//            {
//                return UnprocessableEntity("Account already exists");
//            }

//            PasswordHasher hasher = new PasswordHasher();
//            string hashedPassword = hasher.Hash(model.Password);

//            try
//            {
//                var userModel = new User
//                {
//                    FirstName = model.FirstName,
//                    LastName = model.LastName,
//                    ImageUrl = model.ImageUrl,
//                };
//                _dataContext.Users.Add(userModel);
//                await _dataContext.SaveChangesAsync();

//                var credentialModel = new UserCredential
//                {
//                    UserId = userModel.Id,
//                    Email = model.Email,
//                    Password = hashedPassword,
//                };
//                _dataContext.UserCredentials.Add(credentialModel);

//                await _dataContext.SaveChangesAsync();

//                return Ok();
//            }
//            catch (Exception ex) 
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        [HttpPost("login")]
//        public async Task<ActionResult<User>> LoginUser([FromBody] UserLoginDTO model)
//        {
//            try
//            {
//                var user = await _dataContext.UserCredentials.SingleOrDefaultAsync(u => u.Email == model.Email);

//                if (user is null) return Unauthorized();

//                PasswordHasher hasher = new PasswordHasher();
//                bool passwordCheck = hasher.Verify(model.Password, user.Password);

//                if (passwordCheck)
//                {
//                    return Ok();
//                } 
//                else 
//                {
//                    return Unauthorized();
//                }
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        [HttpDelete("{id}")]
//        public async Task<ActionResult<User>> DelelteUser(int id)
//        {
//            try
//            {
//                var user = await _dataContext.Users.FindAsync(id);
//                var credential = await _dataContext.UserCredentials.SingleOrDefaultAsync(u => u.UserId == id);

//                if (user is null) return NotFound("User not found");

//                _dataContext.Users.Remove(user);
//                _dataContext.UserCredentials.Remove(credential!);
//                await _dataContext.SaveChangesAsync();

//                return Ok();
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }
//    }
//}
