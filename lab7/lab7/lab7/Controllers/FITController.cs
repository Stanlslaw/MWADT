using lab7.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lab7.Controllers;

public class FITController:Controller
{
    [Authorize(Roles = $"{Roles.Employer},{Roles.Guest}")]
    public async Task<IActionResult> Index()
    {
        return View();
    }
    [Authorize(Roles=Roles.Employer)]
    public async Task<IActionResult> FIT_IS()
    {
        return View();
    }
    [Authorize(Roles=Roles.Employer)]
    public async Task<IActionResult> FIT_PI()
    {
        return View();
    }
    [Authorize(Roles=Roles.Employer)]
    public async Task<IActionResult> FIT_ID()
    {
        return View();
    }
}