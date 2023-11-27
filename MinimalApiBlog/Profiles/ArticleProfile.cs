using AutoMapper;
using MinimalApiBlog.Entities;
using MinimalApiBlog.Models.Article;
using MinimalApiBlog.Models.Author;

namespace MinimalApiBlog.Profiles;

public class ArticleProfile : Profile
{
    public ArticleProfile()
    {
        CreateMap<Article, ArticleDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn))
            .ForMember(dest => dest.ContentUrl, opt => opt.MapFrom(src => src.ContentUrl));

        CreateMap<ArticleCreationDto, Article>();
    }
}

