using Microsoft.AspNetCore.Mvc;
using API.ViewsBook;
using API.Infrastructure;
using API.ModelBooks;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    IServiceModel<Book> _context; 
    public BookController(IServiceModel<Book> context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<ViewBook>> Get()
    {
        /*var allBooks = await _context.Books.ToListAsync();
        if (allBooks == null) 
            return NotFound();

        return Ok(allBooks);*/

        var x = await Task.Run(delegate ()
        {
            return _context.get().Select(u => ViewConvertor.BookToView(u));
        });
        return x;
    }

    [HttpGet("{Id}")]
    public async Task<ViewBook> Get([FromQuery] Guid Id)
    {
        /*if (Id != Guid.Empty)
        {
            var book = await _context.Books.FindAsync(Id);
            return Ok(book);
        }
        return BadRequest(nameof(Id));*/

        var x = await Task.Run(delegate ()
        {
            var book = _context.get(Id);
            return ViewConvertor.BookToView(book);
        });
        return x;
    }

    [HttpPost]
    public async Task<ActionResult<ViewBook>> Post([FromBody] ViewBook viewbook)
    {
        /*if (viewbook.Id != Guid.Empty)
        {
            var post = _context.Books.Add(viewbook);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetBook", viewbook);
        }
        return BadRequest();*/

        if (viewbook.Id == Guid.Empty)
        {
            var Book = _context.Add(ViewConvertor.ViewToBook(viewbook));
            return ViewConvertor.BookToView(Book);
        }
        var book = _context.Upd(viewbook.Id, ViewConvertor.ViewToBook(viewbook));
        return ViewConvertor.BookToView(book);
    }

    [HttpPost("{Id}")]
    public async Task<ActionResult<ViewBook>> PostId([FromQuery] Guid Id, [FromBody] ViewBook viewBook)
    {
        if (Id != Guid.Empty)
        {
            /*var book = await _context.Books.FindAsync(Id);
            _context.Books.Update(book);
            await _context.SaveChangesAsync();*/

            viewBook.Id = Id;
            var book = _context.Upd(Id, ViewConvertor.ViewToBook(viewBook));
            return ViewConvertor.BookToView(book);
        }
        return BadRequest(nameof(Id));
    }
}