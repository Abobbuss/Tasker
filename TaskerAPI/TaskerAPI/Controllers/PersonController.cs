using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskerAPI.Data;
using TaskerAPI.Models;

namespace TaskerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly TaskerAPIDbContext _context;
        public PersonController(TaskerAPIDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPerson()
        {
            var persons = _context.people.ToList();

            return Ok(persons);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetPersonDetail([FromRoute] int id)
        {
            var person = _context.people.Find(id);

            return Ok(person);
        }

        [HttpPost]
        public async Task<IActionResult> AddPerson([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest("null");
            }

            if (ModelState.IsValid)
            {
                _context.people.Add(person);
                await _context.SaveChangesAsync();
                return Ok(person);
            }
            else
            {
                return BadRequest("Invalid data");
            }
        }
    }
}
