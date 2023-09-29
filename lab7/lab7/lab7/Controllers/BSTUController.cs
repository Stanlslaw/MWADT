using Microsoft.AspNetCore.Mvc;

namespace lab7.Controllers;

public class BSTUController:Controller
{
    public async Task<IActionResult> Index()
    {
        
        return View("~/Views/BSTUIndex.cshtml");
    }
}