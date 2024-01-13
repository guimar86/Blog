using System.Globalization;
using AutoMapper;
using BlogApi.Models.DTO;

namespace BlogApi.Models;

public class MapConfig : Profile
{
    public MapConfig()
    {
        CreateMap<User, UserCreateDto>().ReverseMap();
        CreateMap<User, User>()
            .ForMember(dest => dest.CreatedAt,
                opt => opt.Condition(src =>
                    (!src.CreatedAt.ToString(CultureInfo.InvariantCulture).Equals("0001-01-01T00:00:00"))));
        CreateMap<User, UserDTO>()
            .ReverseMap()
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore()) // Ignore mapping for CreatedAt
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
        CreateMap<BlogPostDTO, BlogPost>()
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore()) // Ignore mapping for CreatedAt
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
            .ReverseMap();
        CreateMap<BlogPost, CreateBlogPostRequest>().ReverseMap();
        CreateMap<BlogPost, BlogPost>()
            .ForMember(dest => dest.CreatedAt,
                opt => opt.Condition(src =>
                    (!src.CreatedAt.ToString(CultureInfo.InvariantCulture).Equals("0001-01-01T00:00:00"))));

        CreateMap<CommentDto, Comment>().ReverseMap();
        CreateMap<CreateCommentDto, Comment>()
            .ForMember(dest => dest.Author, opt => opt.Ignore())
            .ForMember(dest => dest.BlogPost, opt => opt.Ignore())
            .ReverseMap();
        CreateMap<UpdateCommentDto, Comment>().ReverseMap();
    }
}