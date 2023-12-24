using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace API.Abstract
{
    public abstract class AppModel : DbContext
    {
        public AppModel(DbContextOptions<AppModel> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
