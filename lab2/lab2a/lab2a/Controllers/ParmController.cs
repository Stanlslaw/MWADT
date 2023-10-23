using Microsoft.AspNetCore.Mvc;

namespace lab2a.Controllers;
[Route("Parm")]
public class ParmController:Controller
{
    [Route("{action}/{Id?}")]
    public IActionResult Index(string? Id)
    {
        ViewBag.Id = Id;
        return View();
    }
    [Route("{action}/{Id?}")]
    public IActionResult Uri01(int? Id)
    {
        ViewBag.Id = Id;
        return View();
    }
    [Route("{action}/{Id?}")]
    public IActionResult Uri02(int? Id)
    {
        ViewBag.Id = Id;
        return View();
    }
    [Route("{action}/{Id?}")]
    public IActionResult Uri03(float? Id)
    {
        ViewBag.Id = Id;
        return View();
    }
    [Route("{action}/{Id?}")]
    public IActionResult Uri04(DateTime? Id)
    {
        ViewBag.Id = Id;
        return View();
    }
}