using Microsoft.AspNetCore.Mvc;
using TaskerAPI.Data;
using TaskerAPI.Models;

namespace TaskerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        private readonly TaskerAPIDbContext _context;

        public ProjectController(TaskerAPIDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetProjects()
        {
            var projects = _context.Projects.ToList();

            return Ok(projects);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetProjectDetail([FromRoute] int id)
        {
            var project = _context.Projects.Find(id);

            if (project == null)
            {
                return NotFound(); 
            }

            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> AddProject([FromBody] Project project)
        {
            if (project == null)
            {
                return BadRequest("null");
            }

            if (ModelState.IsValid)
            {
                _context.Projects.Add(project);
                await _context.SaveChangesAsync();
                return Ok(project);
            }
            else
            {
                return BadRequest("Invalid data");
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateProject([FromRoute] int id, [FromBody] Project updatedProject)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
            {
                return NotFound(); 
            }

            project.Name = updatedProject.Name ?? project.Name;

            await _context.SaveChangesAsync();

            return Ok(project);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteProject([FromRoute] int id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
            {
                return NotFound(); 
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return Ok(project);
        }
    }
}
