namespace SimpleBlog.HandleExceptions.NotFound
{
    public class InvalidBlog:NotFoundException
    {
        public InvalidBlog() : base("InValid Blog..Insert Correct Blog")
        {
            
        }
    }
}
