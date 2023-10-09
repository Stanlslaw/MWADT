using Microsoft.AspNetCore.Mvc;

namespace lab2a.Controllers;

public class StartController:Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult One()
    {
        return Ok("Start/One");
    }
    public IActionResult Two()
    {
        return Ok("Start/Two");
    }
    public IActionResult Three()
    {
        return Ok("Start/Three");
    }
    
}