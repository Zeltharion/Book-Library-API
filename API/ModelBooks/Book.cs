using API.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace API.ModelBooks
{
    [PrimaryKey(nameof(Id))]
    public class Book:IUpdate<Book>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        Book IUpdate<Book>.Update(Book? book)
        {
            if (book is not null)
            {
                Update(book);
            }
            return this;
        }
    }
}