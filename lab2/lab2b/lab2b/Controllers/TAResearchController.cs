using Microsoft.AspNetCore.Mvc;

namespace lab5b.Controllers;

[Route("it")]
public class TAResearchController:Controller
{
    [HttpGet]
    [Route("{num:int}/{str:maxlength(32)}")]
    public async Task<string> M04(int num,string str)
    {
        return $"{Request.Method}:M04:/{num}/{str}";
    }

    [HttpGet]
    [HttpPost]
    [Route("{b:bool}/{letters:alpha}")]
    public async Task<string> M05(bool b, string letters)
    {
        return $"{Request.Method}:M05:/{b}/{letters}";
    }

    [HttpGet]
    [HttpDelete]
    [Route("{f:float}/{str:minlength(2):maxlength(5)}")]
    public async Task<string> M06(float f, string str)
    {
        return $"{Request.Method}:M06:/{f}/{str}";
    }
    [HttpPut]
    [Route("{letters:alpha:minlength(3):maxlength(4)}/{n:int:range(100,200)}")]
    public async Task<string> M07(int? n, string? letters)
    {
        return $"{Request.Method}:M07:/{letters}/{n}";
    }
    [HttpPost]
    [Route("{mail:regex(^\\S+@\\S+\\.\\S+$)}")]
    public async Task<string> M08(string? mail)
    {
        return $"{Request.Method}:M08:/{mail}";
    }

}