using System.Globalization;
using AutoMapper;
using BlogApi.Models.DTO;

namespace BlogApi.Models;

public class MapConfig : Profile
{
    public MapConfig()
    {
        CreateMap<User, UserCreateDTO>().ReverseMap();
        CreateMap<User, User>()
            .ForMember(dest => dest.CreatedAt,
                opt => opt.Condition(src =>
                    (!src.CreatedAt.ToString(CultureInfo.InvariantCulture).Equals("0001-01-01T00:00:00"))));
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<BlogPost, BlogPostDTO>().ReverseMap();
        CreateMap<BlogPost, BlogPostCreateDTO>().ReverseMap();
        CreateMap<BlogPost, BlogPost>()
            .ForMember(dest => dest.CreatedAt,
                opt => opt.Condition(src =>
                    (!src.CreatedAt.ToString(CultureInfo.InvariantCulture).Equals("0001-01-01T00:00:00"))));
    }
}