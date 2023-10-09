using Microsoft.AspNetCore.Mvc;

namespace lab2a.Controllers;

public class ParmController:Controller
{
    public IActionResult Index(string Id)
    {
        ViewBag.Id = Id;
        return View();
    }
    public IActionResult Uri01(int Id)
    {
        ViewBag.Id = Id;
        return View();
    }
    public IActionResult Uri02(int? Id)
    {
        ViewBag.Id = Id;
        return View();
    }
    public IActionResult Uri03(float Id)
    {
        ViewBag.Id = Id;
        return View();
    }
    public IActionResult Uri01(DateTime Id)
    {
        ViewBag.Id = Id;
        return View();
    }
}