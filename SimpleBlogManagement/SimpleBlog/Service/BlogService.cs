using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpleBlog.Data;
using SimpleBlog.DTO;
using SimpleBlog.HandleExceptions.NotFound;
using SimpleBlog.Models;
using SimpleBlog.Repository.Extensions;
using SimpleBlog.RequestFeatures;

namespace SimpleBlog.Service
{
    public class BlogService : IBlogService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<AppDbContext> _logger;
        private readonly IMapper _mapper;
        //Delete OP
        public BlogService(AppDbContext context, ILogger<AppDbContext> logger,
           IMapper mapper )
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }
        //--------------------------------------------------------
        //Create Op    
        public async Task<BlogDTO> CreateAsync(BlogForCreationDTO blogdto)
        {
            if (blogdto is null)
                throw new InvalidBlog();
            var blogEntity = _mapper.Map<Blog>(blogdto);

             _context.Blogs.Add(blogEntity);
            await _context.SaveChangesAsync();
            
            var blogToReturn = _mapper.Map<BlogDTO>(blogEntity);
            return blogToReturn;
        }

        //--------------------------------------------------------
        //Read Op  
        public async Task<IEnumerable<BlogDTO>> GetAllAsync()
        {
            try
            {
                var blogs = await _context.Blogs.ToListAsync();
                var blogsDto = _mapper.Map<IEnumerable<BlogDTO>>(blogs);
                return blogsDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllAsync)} service method {ex}");
                throw;
            }

        }
        public async Task<BlogDTO> GetByIdAsyc(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog is null)
                throw new NotFoundBlog(id);
            var blogDto = _mapper.Map<BlogDTO>(blog);

            return blogDto;
        }
        public async Task<IEnumerable<BlogDTO>> GetAllPaginationAsync(BlogParameters blogParameters)
        {
            try
            {
                var blogs = await _context.Blogs
                    .Skip((blogParameters.PageNumber - 1) * blogParameters.PageSize)
                    .Take(blogParameters.PageSize)
                    .ToListAsync();

                var blogsDto = _mapper.Map<IEnumerable<BlogDTO>>(blogs);
                return blogsDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllAsync)} service method {ex}");
                throw;
            }
        }
        public async Task<IEnumerable<BlogDTO>> SearchingBlogsAsync(BlogParameters blogParameters)
        {
            try
            {
                var blogs = await _context.Blogs
                    .Search(blogParameters.SearchTerm)
                    .ToListAsync();

                var blogsDto = _mapper.Map<IEnumerable<BlogDTO>>(blogs);
                return blogsDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllAsync)} service method {ex}");
                throw;
            }
        }
        //--------------------------------------------------------
        //Update OP
        public async Task UpdateAsync(int id, UpdateBlogDTO blogDto)
        {
            var blog = await _context.Blogs.FindAsync(id);

            if (blog is null)
                return;

            _mapper.Map(blogDto, blog);
            await _context.SaveChangesAsync();
        }
        //--------------------------------------------------------
        //Delete OP
        public async Task DeleteAsync(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);

            if (blog is null)
                throw new NotFoundBlog(id);
       
            _context.Remove(blog);
            await _context.SaveChangesAsync();
        }

       
    }
}
