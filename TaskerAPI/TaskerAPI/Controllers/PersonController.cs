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
            var persons = _context.People.ToList();

            return Ok(persons);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetPersonDetail([FromRoute] int id)
        {
            var person = _context.People.Find(id);

            if (person == null)
            {
                return NotFound();
            }

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
                _context.People.Add(person);
                await _context.SaveChangesAsync();
                return Ok(person);
            }
            else
            {
                return BadRequest("Invalid data");
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdatePerson([FromRoute] int id, [FromBody] Person updatedPerson)
        {
            var person = await _context.People.FindAsync(id);

            if (person == null)
            {
                return NotFound(); 
            }

            person.Name = updatedPerson.Name ?? person.Name;
            person.FirstName = updatedPerson.FirstName ?? person.FirstName;
            person.MiddleName = updatedPerson.MiddleName ?? person.MiddleName;

            await _context.SaveChangesAsync();

            return Ok(person);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeletePerson([FromRoute] int id)
        {
            var person = await _context.People.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            _context.People.Remove(person);
            await _context.SaveChangesAsync();

            return Ok(person);
        }
    }

}
