using MealDelightAPI.Data;
using MealDelightAPI.Data.Entities;
using MealDelightAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MealDelightAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly DataContext _dataContext;

        public PersonController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetAllPerson()
        {
            var persons = await _dataContext.Person.ToListAsync();

            return Ok(persons);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPersonById(int id)
        {
            var person = await _dataContext.Person.FindAsync(id);

            if (person is null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult<Person>> AddPerson([FromBody] PersonModel model)
        {
            var personModel = new Person 
            { 
                FirstName = model.FirstName, 
                LastName = model.LastName 
            };

            _dataContext.Person.Add(personModel);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Person.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Person>>> UpdatePerson([FromBody] Person person)
        {
            var dbPerson = await _dataContext.Person.FindAsync(person.Id);
            
            if (dbPerson is null)
            {
                return NotFound();
            }

            dbPerson.FirstName = person.FirstName;
            dbPerson.LastName = person.LastName;

            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Person.ToListAsync());
        }
    }
}
