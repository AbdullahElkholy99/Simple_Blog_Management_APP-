using SimpleBlog.Models;

namespace SimpleBlog.Repository.Extensions
{
    public static class RepositoryBlogExtensions
    {
        public static IQueryable<Blog> Search(this IQueryable<Blog> employees, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) 
                return employees;

            var lowerCaseTerm = searchTerm.Trim().ToLower(); 
            return employees.Where(e => e.Title.ToLower().Contains(lowerCaseTerm));
        }
    }
}
