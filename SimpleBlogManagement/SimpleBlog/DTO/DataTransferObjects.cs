namespace SimpleBlog.DTO
{
    public record BlogDTO(int Id , string Title,string Content, string AuthorName , DateTime CreatedDate);
    public record BlogForCreationDTO(string Title,string Content, string AuthorName , DateTime CreatedDate);
    //public record CreateBlogDTO : BlogRecord;
    public record UpdateBlogDTO(string Title, string Content, string AuthorName, DateTime CreatedDate);


}
