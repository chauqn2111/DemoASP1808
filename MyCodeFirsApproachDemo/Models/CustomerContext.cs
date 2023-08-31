using Microsoft.EntityFrameworkCore;

namespace MyCodeFirsApproachDemo.Models
{
    public class CustomerContext: DbContext
    {
        public CustomerContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true);
            IConfiguration configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DemoWAD"));
        }
        public virtual DbSet<Customer> People { get; set;}
    }
}
