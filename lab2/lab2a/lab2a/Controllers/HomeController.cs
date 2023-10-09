using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using lab2a.Models;

namespace lab2a.Controllers;
[Route("")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    
    [Route("")]
    public IActionResult Index()
    {
        return  RedirectPermanent("/index.html");
    }
    [Route("privacy")]
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [Route("error")]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}