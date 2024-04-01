using MinimalApiBlog.Models.Article;
using MiniValidation;

namespace MinimalApiBlog.EndpointFilters;

public class ValidateAnnotationsFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var articleForCreationDto = context.GetArgument<ArticleCreationDto>(2);

        if (!MiniValidator.TryValidate(articleForCreationDto, out var validationErrors))
        {
            return TypedResults.ValidationProblem(validationErrors);
        }

        return await next(context);
    }
}