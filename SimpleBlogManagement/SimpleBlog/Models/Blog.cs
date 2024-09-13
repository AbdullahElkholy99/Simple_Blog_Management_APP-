using System.ComponentModel.DataAnnotations;

namespace SimpleBlog.Models
{
    public class Blog
    {
        public int Id { get; set; }

        [Length(3, 30, ErrorMessage = "MinLenght is 3 char.. and MaxLength is 30 Char..")]
        public string Title { get; set; }

        [Length(10, 500, ErrorMessage = "MinLenght is 10 char.. and MaxLength is 500 Char..")]
        public string Content { get; set; }

        [Length(3, 30, ErrorMessage = "MinLenght is 3 char.. and MaxLength is 30 Char..")]
        public string AuthorName { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;
    }
}
