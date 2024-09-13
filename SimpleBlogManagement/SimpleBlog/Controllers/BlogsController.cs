using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SimpleBlog.DTO;
using SimpleBlog.HandleExceptions.NotFound;
using SimpleBlog.RequestFeatures;
using SimpleBlog.Service;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SimpleBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogService _service;

        public BlogsController(IBlogService blogService) => _service = blogService;

        //--------------------------------------
        //Create Op Work
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(BlogForCreationDTO blog)
        {
            if (blog is null)
                throw new InvalidBlog();
             var createdBlog = await _service.CreateAsync(blog);
            
            return Ok(createdBlog);
        }

        //--------------------------------------
        //Read Op  Work
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GellAll()
        {
            var blogs = await _service.GetAllAsync();
            if (blogs.IsNullOrEmpty())
                throw new NotFoundBlogs();

            return Ok(blogs);
        }
        [HttpGet]
        [Route("GetById/{id:int}")]
        public async Task<IActionResult> GellById(int id)
        {
            var blog = await CheckIfBlogExistById(id);

            if (blog is null)
                throw new NotFoundBlog(id);
          
            return Ok(blog);
        }

        [HttpGet("BlogsWithPagination")]
        public async Task<IActionResult> GetBlogsWithPagination([FromQuery]BlogParameters blogParameters)
        {
            var blogs = await _service.GetAllPaginationAsync(blogParameters);
            if (blogs.IsNullOrEmpty())
                throw new NotFoundBlogs();

            return Ok(blogs);
         }
        [HttpGet("SearchingByTitle")]
        public async Task<IActionResult> SearchingByTitle([FromQuery] BlogParameters blogParameters)
        {
            var blogs = await _service.SearchingBlogsAsync(blogParameters);

            if (blogs.IsNullOrEmpty())
                throw new NotFoundBlogs();

            return Ok(blogs);
        }
        //--------------------------------------
        //Read Op
        [HttpPut]
         [Route("Update/{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateBlogDTO newBlog)
        {
            await CheckIfBlogExistById(id);

            if (newBlog is null)
                throw new InvalidBlog();
            await _service.UpdateAsync(id, newBlog);

            return Ok("Success Updated");
        }

        //--------------------------------------
        //Read Op
        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await CheckIfBlogExistById(id);

            await _service.DeleteAsync(id);

            return Ok($"Succees Deleted Blog Id : {id}");
        }
        //--------------------------------------
        //Private Methods : 
        private async Task<BlogDTO> CheckIfBlogExistById(int id)
        {
            var blog = await _service.GetByIdAsyc(id);
            if (blog is null)
                throw new NotFoundBlog(id);

            return blog;
        }
    }
}
