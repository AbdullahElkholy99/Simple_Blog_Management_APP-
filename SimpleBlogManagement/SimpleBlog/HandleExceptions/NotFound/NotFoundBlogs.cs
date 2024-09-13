namespace SimpleBlog.HandleExceptions.NotFound
{
    public class NotFoundBlogs : NotFoundException
    {
        public NotFoundBlogs() : base("No There Blogs!!!!")
        {
            
        }
    }
}
