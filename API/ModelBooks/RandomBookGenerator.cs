namespace API.ModelBooks
{
    public static class RandomBookGenerator
    {
        public static Book GenerateRandomBook()
        {
            Random random = new Random();
            Book book = new Book();
            book.Id = Guid.NewGuid();
            book.Title = "Book Title " + random.Next(1, 1000);
            book.Description = "Description of the book";
            book.Author = "Author Name";
            book.PublishedDate = new DateTime(random.Next(2000, 2022), random.Next(1, 13), random.Next(1, 29));
            book.Genre = "Fantasy";
            book.TakenStatus = random.Next(0, 2) == 1 ? true : false;
            book.Condition = random.Next(0, 2) == 1 ? true : false;

            return book;
        }
    }
}
