

using API.Infrastructure;

namespace API.ModelBooks
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Genre { get; set; }
        public bool TakenStatus { get; set; } // Занята или нет
        public bool Condition { get; set; } // Состояние самой книги

        private void Update(Book e)
        {
            Title = e.Title;
            Description = e.Description;
            Author = e.Author;
            PublishedDate = e.PublishedDate;
            Genre = e.Genre;
            TakenStatus = e.TakenStatus;
            Condition = e.Condition;
        }
    }
}