using AutoMapper;
using MinimalApiBlog.Entities;
using MinimalApiBlog.Models.Article;

namespace MinimalApiBlog.Profiles;

public class ArticleProfile : Profile
{
    public ArticleProfile()
    {
        CreateMap<Article, ArticleDto>();
    }
}