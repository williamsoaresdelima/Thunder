using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TaskList.Data.Entities;

namespace TaskList.Data.Context
{
    public class ContextDb : DbContext
    {
        public IConfiguration Configuration { get; set; }
        public ContextDb(DbContextOptions<ContextDb> options)
            : base(options = new DbContextOptions<ContextDb>())
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        public DbSet<TaskEntity> Task { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseNpgsql(configuration.GetConnectionString("TaskConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            typeof(BaseEntity)
            .Assembly
            .GetTypes()
                .Where(t =>
                    t.IsSubclassOf(typeof(BaseEntity)) &&
                !t.IsAbstract)
                .Select(t => Activator.CreateInstance(t) as BaseEntity)
                .ToList()
                .ForEach(x => x.EntityMap(modelBuilder));
        }
    }
}
