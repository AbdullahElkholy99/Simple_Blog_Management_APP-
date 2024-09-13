using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleBlog.Models;

namespace SimpleBlog.Data.Configuration
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasData(
                new Blog
                {
                    Id= 1,
                    Title="ASP.Net",
                    Content="I Love Asp.Net",
                    AuthorName="Abdullah Ali",
                    CreatedDate= DateTime.Now
                },
                new Blog
                {
                    Id = 2,
                    Title = "API Core",
                    Content = "I Love API Core",
                    AuthorName = "Malak Mohamed",
                    CreatedDate = DateTime.Now
                },
                new Blog
                {
                    Id = 3,
                    Title = "MVC Core",
                    Content = "I Love MVC Core",
                    AuthorName = "Omar Ali",
                    CreatedDate = DateTime.Now
                }
            );
        }
    }
}
