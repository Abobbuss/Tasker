using Microsoft.AspNetCore.Mvc;
using TaskerAPI.Data;
using TaskerAPI.Models;

namespace TaskerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : Controller
    {
        private readonly TaskerAPIDbContext _context;

        public CommentController(TaskerAPIDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetComments()
        {
            var comments = _context.Comments.ToList();

            return Ok(comments);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetCommentDetail([FromRoute] int id)
        {
            var comment = _context.Comments.Find(id);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment([FromBody] Comment comment)
        {
            if (comment == null)
            {
                return BadRequest("null");
            }

            if (ModelState.IsValid)
            {
                _context.Comments.Add(comment);
                await _context.SaveChangesAsync();
                return Ok(comment);
            }
            else
            {
                return BadRequest("Invalid data");
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateComment([FromRoute] int id, [FromBody] Comment updatedComment)
        {
            var comment = await _context.Comments.FindAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            comment.Text = updatedComment.Text ?? comment.Text;

            await _context.SaveChangesAsync();

            return Ok(comment);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteComment([FromRoute] int id)
        {
            var comment = await _context.Comments.FindAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return Ok(comment);
        }
    }

}
