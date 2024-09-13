using Microsoft.EntityFrameworkCore;
using SimpleBlog.Data.Configuration;
using SimpleBlog.Models;

namespace SimpleBlog.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Blog>( new BlogConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Blog>? Blogs { get; set; }
    }
}
