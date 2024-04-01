using MinimalApiBlog.EndpointFilters;
using MinimalApiBlog.EndpointHandlers;

namespace MinimalApiBlog.Extensions;

public static class EndpointRouteBuilderExtensions
{
    public static void RegisterArticlesEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        var articlesEndpoints = endpointRouteBuilder.MapGroup("/articles");
        var articleEndpoint = articlesEndpoints.MapGroup("/{articleId:guid}")
            .AddEndpointFilter<LogNotFoundResponseFilter>();
        var articleEndpointWithLockFilters = endpointRouteBuilder.MapGroup("/articles/{articleId:guid}")
            .AddEndpointFilter(new ArticleIsLockedFilter(new Guid()));

        articlesEndpoints.MapGet("", ArticlesHandlers.GetArticlesAsync);
        articleEndpoint.MapGet("", ArticlesHandlers.GetArticleAsync).WithName("GetArticle");
        articlesEndpoints.MapPost("", ArticlesHandlers.PostArticleAsync)
            .AddEndpointFilter<ValidateAnnotationsFilter>();
        articleEndpointWithLockFilters.MapPut("", ArticlesHandlers.PutArticleAsync);
        articleEndpointWithLockFilters.MapDelete("", ArticlesHandlers.DeleteArticleAsync);
    }

    public static void RegisterTopicEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        var topicsEndpoints = endpointRouteBuilder.MapGroup("/topics");
        var topicEndpoints = topicsEndpoints.MapGroup("/{topicId:guid}");

        topicsEndpoints.MapGet("", TopicsHandlers.GetTopicsAsync);
        topicEndpoints.MapGet("", TopicsHandlers.GetTopicAsync).WithName("GetTopic");
        topicsEndpoints.MapPost("", TopicsHandlers.PostArticleAsync);
        topicEndpoints.MapPut("", TopicsHandlers.PutTopicAsync);
        topicEndpoints.MapDelete("", TopicsHandlers.DeleteTopicAsync);
    }
}