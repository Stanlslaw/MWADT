using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace lab5b.Filters;

public class ExceptionFilter:Attribute,IAsyncExceptionFilter
{
    public async Task OnExceptionAsync(ExceptionContext context)
    {
        string? actionName = context.ActionDescriptor.DisplayName;
        string? exceptionStack = context.Exception.StackTrace;
        string exceptionMessage = context.Exception.Message;
        context.Result = new ContentResult
        {
            Content = $"В методе {actionName} возникло исключение: \n {exceptionMessage} \n {exceptionStack}"
        };
        context.ExceptionHandled = true;
    }
}