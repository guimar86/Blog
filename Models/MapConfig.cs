using AutoMapper;
using BlogApi.Models.DTO;

namespace BlogApi.Models;

public class MapConfig : Profile
{
    
    public MapConfig()
    {
        CreateMap<User, UserCreateDTO>().ReverseMap();
        CreateMap<User, User>();
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<BlogPost, BlogPostDTO>().ReverseMap();
        CreateMap<BlogPost, BlogPostCreateDTO>().ReverseMap();
        CreateMap<BlogPost, BlogPost>();
    }
}