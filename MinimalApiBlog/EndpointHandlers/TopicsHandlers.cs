using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MinimalApiBlog.DbContexts;
using MinimalApiBlog.Entities;
using MinimalApiBlog.Models.Topic;

namespace MinimalApiBlog.EndpointHandlers;

public static class TopicsHandlers
{
    public static async Task<Ok<IEnumerable<TopicDto>>> GetTopicsAsync (
        BlogDbContext blogDbContext, 
        IMapper mapper)
    {
        return TypedResults.Ok(mapper.Map<IEnumerable<TopicDto>>(await blogDbContext.Topics.ToListAsync()));
    }
        
    public static async Task<Results<NotFound, Ok<TopicDto>>> GetTopicAsync(
        Guid topicId, 
        BlogDbContext blogDbContext, 
        IMapper mapper)
    {
        var topic = await blogDbContext.Topics.FirstOrDefaultAsync(a => a.Id == topicId);

        if (topic == null)
        {
            return TypedResults.NotFound();
        }
    
        return TypedResults.Ok(mapper.Map<TopicDto>(topic));
    }
    
    public static async Task<Ok<TopicDto>> PostArticleAsync(
        BlogDbContext blogDbContext, 
        IMapper mapper, 
        TopicCreationDto topic)
    {
        var topicEntity = mapper.Map<Topic>(topic);
        blogDbContext.Add(topicEntity);
        await blogDbContext.SaveChangesAsync();

        var topicToReturn = mapper.Map<TopicDto>(topicEntity);
        return TypedResults.Ok(topicToReturn);
    }

    public static async Task<Results<NotFound, Ok<TopicDto>>> PutTopicAsync(
        Guid topicId,
        BlogDbContext blogDbContext,
        IMapper mapper,
        TopicUpdateDto topicForUpdate)
    {
        var topic = await blogDbContext.Topics.FirstOrDefaultAsync(a => a.Id == topicId);
        
        if (topic == null)
        {
            return TypedResults.NotFound();
        }

        mapper.Map(topicForUpdate, topic);

        await blogDbContext.SaveChangesAsync();
    
        return TypedResults.Ok(mapper.Map<TopicDto>(topic));
    }
}