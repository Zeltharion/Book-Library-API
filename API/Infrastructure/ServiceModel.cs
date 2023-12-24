using API.Abstract;
using API.ModelBooks;

namespace API.Infrastructure
{
    public static class BookService
    {
        public static IServiceCollection BookServiceModel(this IServiceCollection services)
        {
            services.AddDbContext<AppModel>();
            services.AddTransient<IServiceModel<Book>, ServiceModel>();

            return services;
        }
    }
    public class ServiceModel(AppModel _appDB) : AbstractService<Book>(_appDB) 
    {
        AppModel _appDB;

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
