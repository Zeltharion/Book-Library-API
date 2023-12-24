using API.Abstract;
using API.ViewsBook;
using Microsoft.EntityFrameworkCore;

namespace API.ServiceBook.DataBase
{
    public class DbContextBook : AppModel
    {
        public DbSet<ViewBook> Books { get; set; }


        public DbContextBook(DbContextOptions<AppModel> options) : base(options)
        {
            /*Database.Migrate();*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
