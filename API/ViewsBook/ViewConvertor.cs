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

        static public Book ViewToBook(ViewBook viewbook) 
        {
            return new Book()
            {
                Id = viewbook.Id,
                Title = viewbook.Title,
                Description = viewbook.Description,
                Author = viewbook.Author,
                PublishedDate = viewbook.PublishedDate,
                Genre = viewbook.Genre,
                TakenStatus = viewbook.TakenStatus,
                Condition = viewbook.Condition
            };
        }
    }
}
