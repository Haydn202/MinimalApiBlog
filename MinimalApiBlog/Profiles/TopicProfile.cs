using AutoMapper;
using MinimalApiBlog.Entities;
using MinimalApiBlog.Models.Article;

namespace MinimalApiBlog.Profiles;

public class TopicProfile : Profile
{
    public TopicProfile()
    {
        CreateMap<Topic, TopicDto>();
        CreateMap<TopicCreationDto, Topic>();
    }
}