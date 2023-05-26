using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Sale.Infrastructure.Persistence
{
    public static class MigrationFactory
    {
        public static void Migrate(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            if(string.IsNullOrEmpty(connectionString) ) throw new ArgumentNullException(nameof(connectionString));

            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(connectionString);

            var context = new ApplicationDbContext(optionBuilder.Options);

            context.Database.Migrate();
        }
    }
}
