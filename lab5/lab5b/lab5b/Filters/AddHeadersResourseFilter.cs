using Microsoft.AspNetCore.Mvc.Filters;

namespace lab5b.Filters;

public class AddHeadersResourseFilter:Attribute,IAsyncResourceFilter
{
    public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
    {
        context.HttpContext.Response.Headers.Add("DateTime",DateTime.Now.ToString());
        await next();
    }
}