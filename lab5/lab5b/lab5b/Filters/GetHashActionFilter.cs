using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;

namespace lab5b.Filters;

public class GetHashActionFilter:Attribute,IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var md5 = MD5.Create();
        var password = context.ActionArguments["password"]?.ToString();
        if (password == null) {await next();}
        else
        {
            context.ActionArguments["password"] =
                Convert.ToBase64String(md5.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }
        await next();
    }
}