namespace API.ViewsBook
{
    public class ViewBook
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Genre { get; set; }
        public bool TakenStatus { get; set; } // Занята или нет
        public bool Condition { get; set; } // Состояние самой книги
    }
}
