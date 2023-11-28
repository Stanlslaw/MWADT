using lab7.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lab7.Controllers;

public class FLTController:Controller
{
    [Authorize(Roles = $"{Roles.Employer},{Roles.Guest}")]
    public async Task<IActionResult> Index()
    {
        return View();
    }
    [Authorize(Roles=Roles.Employer)]
    public async Task<IActionResult> FLT_LV()
    {
        return View();
    }
    [Authorize(Roles=Roles.Employer)]
    public async Task<IActionResult> FLT_LU()
    {
        return View();
    }
    [Authorize(Roles=Roles.Employer)]
    public async Task<IActionResult> FLT_LZ()
    {
        return View();
    }
}