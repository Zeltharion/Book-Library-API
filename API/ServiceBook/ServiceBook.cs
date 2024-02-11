using API.Abstract;
using API.Infrastructure;
using API.ModelBooks;

namespace API.ServiceBook
{
    public static class MyExtentionDisease
    {
        public static IServiceCollection AddMyService(this IServiceCollection services)
        {
            //services.AddDbContext<DbContextBook>();
            services.AddScoped<IServiceModel<Book>, ServiceBook>();

            return services;
        }
    }


    public class ServiceBook : AbstractBaseServise<Book>
    {
        AppModel _appDB;
        public ServiceBook(DbContextBook _appDB) : base(_appDB)
        {

        }

        public IEnumerable<Book> getBook()
        {
            return base.GetValues();
        }

        public Book? UpdBook(Book Book)
        {
            return base.UpdValue(Book.Id, Book);
        }

        public Book? AddBook(Book Book)
        {
            return base.setValue(Book);
        }

        public Book getBook(Guid Id)
        {
            return base.GetValue(Id);
        }
    }
}
