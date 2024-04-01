using Microsoft.AspNetCore.Mvc;

namespace MinimalApiBlog.EndpointFilters;

public class ArticleIsLockedFilter : IEndpointFilter
{
    private readonly Guid _lockedArticleId;
    
    public ArticleIsLockedFilter(Guid lockedArticleId)
    {
        _lockedArticleId = lockedArticleId;
    }
    
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var articleId = context.HttpContext.Request.Method switch
        {
            "PUT" => context.GetArgument<Guid>(2),
            "DELETE" => context.GetArgument<Guid>(1),
            _ => throw new NotSupportedException("This filter is not supported for this scenario.")
        };

        if (articleId == _lockedArticleId)
        {
            return TypedResults.Problem(new ProblemDetails
            {
                Status = 400,
                Title = "This article is locked",
                Detail = "This article cannot be modified"
            });
        }

        return await next.Invoke(context);
    }
}