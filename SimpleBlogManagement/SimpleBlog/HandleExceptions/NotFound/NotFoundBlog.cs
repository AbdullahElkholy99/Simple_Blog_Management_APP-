namespace SimpleBlog.HandleExceptions.NotFound
{
    public class NotFoundBlog : NotFoundException
    {
        public NotFoundBlog(int id):base($"The Blog With Id: '{id}' Doesn't Exist In The Database.")
        {
            
        }
    }
}
