using API.ModelBooks;

namespace API.ServiceBook
{
    public interface IServiceBook
    {
        Book AddBook(Book books);
        Book UpdateBook(Guid Id,Book books);
        Book GetBook(Guid Id);
        IEnumerable<Book> GetAllBooks();
    }
}
