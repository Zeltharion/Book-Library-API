using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using API.ServiceBook;
using API.ViewsBook;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly DbContextBook _context; 
    public BookController(DbContextBook context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<ViewBook>> GetAllBooks()
    {
        var allBooks = await _context.Books.ToListAsync();
        if (allBooks == null) 
            return NotFound();

        return Ok(allBooks);
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<ViewBook>> GetBook([FromQuery] Guid Id)
    {
        if (Id != Guid.Empty)
        {
            var book = await _context.Books.FindAsync(Id);
            return Ok(book);
        }
        return BadRequest(nameof(Id));
    }

    [HttpPost]
    public async Task<ActionResult<ViewBook>> AddBook([FromBody] ViewBook viewbook)
    {
        if (viewbook.Id != Guid.Empty)
        {
            var post = _context.Books.Add(viewbook);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetBook", viewbook);
        }
        return BadRequest();
    }

    [HttpPost("{Id}")]
    public async Task<ActionResult<ViewBook>> AddBookId([FromQuery] Guid Id, [FromBody] ViewBook viewBook)
    {
        if (Id != Guid.Empty)
        {
            var book = await _context.Books.FindAsync(Id);
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }
        return BadRequest(nameof(Id));
    }
}