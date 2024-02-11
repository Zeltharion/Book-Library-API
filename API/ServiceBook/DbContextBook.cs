using API.Abstract;
using API.ViewsBook;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace API.ServiceBook
{
    public class DbContextBook : AppModel
    {
        public DbSet<ViewBook> Books { get; set; }

        public DbContextBook(DbContextOptions options) : base(options)
        {
            Books = Set<ViewBook>();
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<ViewBook>().Property(u => u.Id).ValueGeneratedOnAdd();
        }
    }
}
