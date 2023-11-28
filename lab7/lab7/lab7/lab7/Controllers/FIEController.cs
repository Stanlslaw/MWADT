using lab7.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lab7.Controllers;

public class FIEController:Controller
{
    [Authorize(Roles = $"{Roles.Employer},{Roles.Guest}")]
    public async Task<IActionResult> Index()
    {
        return View();
    }
    [Authorize(Roles=Roles.Employer)]
    public async Task<IActionResult> FIE_TM()
    {
        return View();
    }
    [Authorize(Roles=Roles.Employer)]
    public async Task<IActionResult> FIE_UR()
    {
        return View();
    }
    [Authorize(Roles=Roles.Employer)]
    public async Task<IActionResult> FIE_UP()
    {
        return View();
    }
}