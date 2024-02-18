using MinimalApiBlog.EndpointHandlers;

namespace MinimalApiBlog.Extensions;

public static class EndpointRouteBuilderExtensions
{
    public static void RegisterArticlesEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        var articlesEndpoints = endpointRouteBuilder.MapGroup("/articles");
        var articleEndpoint = articlesEndpoints.MapGroup("/{articleId:guid}");

        articlesEndpoints.MapGet("", ArticlesHandlers.GetArticlesAsync);
        articleEndpoint.MapGet("", ArticlesHandlers.GetArticleAsync).WithName("GetArticle");
        articlesEndpoints.MapPost("", ArticlesHandlers.PostArticleAsync);
    }

    public static void RegisterTopicEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        var topicsEndpoints = endpointRouteBuilder.MapGroup("/topics");
        var topicEndpoints = topicsEndpoints.MapGroup("/{topicId:guid}");

        topicsEndpoints.MapGet("", TopicsHandlers.GetTopicsAsync);
        topicEndpoints.MapGet("", TopicsHandlers.GetTopicAsync);
        topicsEndpoints.MapPost("", TopicsHandlers.PostArticleAsync);
    }
}