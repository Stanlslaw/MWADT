using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace lab5b.Controllers;

[Microsoft.AspNetCore.Mvc.Route("cache")]
public class CHResearchController:Controller
{
    [HttpGet]
  
    // [ResponseCache(Duration =10)]
    [OutputCache(Duration = 10)]
    [Route("datetime")]
    public async Task<IActionResult> AD()
    {
        return Content($"{DateTime.Now.ToString()}");
    }
    [HttpGet]
    [HttpPost]
    // [ResponseCache(Duration = 7)]\
    [OutputCache(Duration = 10,VaryByRouteValueNames = new []{"x","y"})]
    [Route("sum")]
    public async Task<IActionResult> AP(int x, int y)
    {
        ViewData["result"] = (x + y).ToString();
        return Content($"res: {x + y}");
        // return View("~/Views/Sum.cshtml");
    }
}