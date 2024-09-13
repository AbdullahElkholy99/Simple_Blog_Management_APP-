using SimpleBlog.DTO;
using SimpleBlog.RequestFeatures;

namespace SimpleBlog.Service
{
    public interface IBlogService
    {
        //Create Blog
        Task<BlogDTO> CreateAsync(BlogForCreationDTO blog);

        //Read 
        Task<IEnumerable<BlogDTO>> GetAllAsync( );
        Task<BlogDTO> GetByIdAsyc(int id );

        Task<IEnumerable<BlogDTO>> GetAllPaginationAsync(BlogParameters blogParameters);
        Task<IEnumerable<BlogDTO>> SearchingBlogsAsync(BlogParameters blogParameters);
        //Update
        Task UpdateAsync(int id, UpdateBlogDTO blogDto);

        //Delete
        Task DeleteAsync(int id);
    }
}
