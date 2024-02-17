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
    public async Task<ActionResult<ViewBook>> GetBook([FromRoute] Guid Id)
    {
        if (Id != Guid.Empty)
        {
            var book = await _context.Books.FindAsync(Id);
            return Ok(book);
        }
        return BadRequest(nameof(Id));
    }

    /*[HttpPost]
    public async Task<ActionResult<ViewBook>> AddBook([FromBody] ViewBook viewbook)
    {
        if (viewbook.Id != Guid.Empty)
        {
            var post = _context.Books.AddAsync(viewbook);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetBook", viewbook);
        }
        return BadRequest();
    }*/

    [HttpPost]
    public async Task<ActionResult<ViewBook>> AddBook([FromBody] ViewBook viewbook)
    {
        if (viewbook.Id == Guid.Empty)
        {
            return BadRequest("Invalid Id");
        }

        var post = await _context.Books.AddAsync(viewbook);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetBook", new { Id = viewbook.Id }, viewbook);
    }

    /* [HttpPost("{Id}")]
     public async Task<ActionResult<ViewBook>> AddBookId([FromQuery] Guid Id, [FromBody] ViewBook viewBook)
     {
         if (Id != Guid.Empty)
         {
             var book = await _context.Books.FindAsync(Id);
             *//*_context.Books.Update(book);*//*
             await _context.SaveChangesAsync();
             return Ok(book);
         }
         return BadRequest(nameof(Id));
     }*/

    [HttpPost("{Id}")]
    public async Task<ActionResult<ViewBook>> AddBookId([FromRoute] Guid Id, [FromBody] ViewBook viewBook)
    {
        if (Id == Guid.Empty)
        {
            return BadRequest("Invalid Id");
        }

        // обновление данных существующей книги
        var book = await _context.Books.FindAsync(Id);
        if (book == null)
        {
            return NotFound();
        }

        // обновление свойств книги
        book.Title = viewBook.Title;
        book.Author = viewBook.Author;
        _context.Books.Update(book);

        await _context.SaveChangesAsync();

        return CreatedAtAction("GetBook", new { Id = viewBook.Id }, viewBook);
    }


}