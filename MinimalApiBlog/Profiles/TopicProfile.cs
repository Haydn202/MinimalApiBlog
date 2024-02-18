using AutoMapper;
using MinimalApiBlog.Entities;
using MinimalApiBlog.Models.Topic;

namespace MinimalApiBlog.Profiles;

public class TopicProfile : Profile
{
    public TopicProfile()
    {
        CreateMap<Topic, TopicDto>();
        CreateMap<TopicCreationDto, Topic>();
        CreateMap<TopicUpdateDto, Topic>();
    }
}