namespace SimpleBlog.HandleExceptions.NotFound
{
    public abstract class NotFoundException : Exception
    {
        public NotFoundException(string msg):base(msg)
        {
            
        }
    }
}
