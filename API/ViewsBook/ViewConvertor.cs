using API.ModelBooks;

namespace API.ViewsBook
{
    static public class ViewConvertor
    {
        static public ViewBook BookToView(Book? book)
        {
            return new ViewBook()
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Author = book.Author,
                PublishedDate = book.PublishedDate,
                Genre = book.Genre,
                TakenStatus = book.TakenStatus,
                Condition = book.Condition
            };
        }

        static public Book ViewToBook(Book? book) 
        {
            return new Book()
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Author = book.Author,
                PublishedDate = book.PublishedDate,
                Genre = book.Genre,
                TakenStatus = book.TakenStatus,
                Condition = book.Condition
            };
        }
    }
}
