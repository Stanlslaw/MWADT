using lab5b.Filters;
using Microsoft.AspNetCore.Mvc;

namespace lab5b.Controllers;
[Route("filters")]
public class AResearchController:Controller
{
    [GetHashActionFilter]//Конечно бред это делать с точки зрения безопасности, но как пример пойдет
    [Route("action/{password:maxlength(8)}")]
    public async Task<string> AA(string password)
    {
        return password;
    }
    [AddHeadersResourseFilter]
    [Route("time")]
    public async Task<string> AR()
    {
        return "";
    }
    [ExceptionFilter]
    [Route("devide")]
    public async Task<string> AE(int num1, int num2)
    {
        return $"{num1 / num2}";
    }
}