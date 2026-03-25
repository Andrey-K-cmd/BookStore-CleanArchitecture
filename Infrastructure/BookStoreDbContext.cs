using Infrastructure.Configurations;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class BookStoreDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<BookEntity> Books { get; set; }

        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
                : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
        }
    }
}
