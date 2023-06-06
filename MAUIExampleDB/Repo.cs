using Microsoft.EntityFrameworkCore;

namespace MAUIExampleDB
{
    public class MyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public interface IRepo
    {
        DbSet<MyModel> Models { get; set; }

        Task MigrateAsync();
        Task SaveChangesAsync();
    }

    public class Repo : DbContext, IRepo
    {
        public Repo(DbContextOptions<Repo> options) : base(options)
        {

        }

        public DbSet<MyModel> Models { get; set; }

        public async Task MigrateAsync()
        {
            await base.Database.MigrateAsync();
        }

        public Task SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyModel>()
                .HasKey(x => x.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}