using AutoMapper;
using SimpleBlog.DTO;
using SimpleBlog.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SimpleBlog.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Blog, BlogDTO>();
            CreateMap<BlogForCreationDTO, Blog>();
            CreateMap<UpdateBlogDTO, Blog>();
        }
    }
}
