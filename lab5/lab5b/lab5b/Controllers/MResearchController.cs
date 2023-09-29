using Microsoft.AspNetCore.Mvc;

namespace lab5b.Controllers;

[Route("it")]
public class MResearchController:Controller
{
    [HttpGet]
    [Route("{num:int}/{str:maxlength(32)}")]
    public async Task<string> M01(int num,string str)
    {
        return $"{Request.Method}:M01:/{num}/{str}";
    }

    [HttpGet]
    [HttpPost]
    [Route("{b:bool}/{letters:alpha}")]
    public async Task<string> M02(bool b, string letters)
    {
        return $"{Request.Method}:M02:/{b}/{letters}";
    }

    [HttpGet]
    [HttpDelete]
    [Route("{f:float}/{str:minlength(2):maxlength(5)}")]
    public async Task<string> M03(float f, string str)
    {
        return $"{Request.Method}:M03:/{f}/{str}";
    }
    [HttpPut]
    [HttpPost]
    [Route("{letters:alpha}/{n:int:range(100,200)}")]
    [Route("{mail:regex(^\\S+@\\S+\\.\\S+$)}")]
    public async Task<string> M04(int? n, string? letters,string? mail)
    {
        return Request.Method == HttpMethods.Post
            ? $"{Request.Method}:M04:/{mail}"
            : $"{Request.Method}:M04:/{letters}/{n}";
    }

}