using Microsoft.AspNetCore.Mvc;

namespace lab3a_new.Controllers;

// 10.  Необходимо реализовать следующие компоненты приложения 
// Calc 	Котроллер 
// Index (метод GET)	Метод контролера Calc
// Sum (метод POST)	Метод контролера Calc
// Sub (метод POST)	Метод контролера Calc
// Mul (метод POST)	Метод контролера Calc
// Div (метод POST)	Метод контролера Calc
// _CalcLink	Частичное представление
// _Calc	Частичное представление

public class CalcController:Controller
{

    [HttpGet]
    public IActionResult Index()
    {
        return View("Calc");
    }

    [HttpGet]
    public IActionResult Sum()
    {
        ViewBag.press = "+";
        return View("Calc");
    }

    [HttpPost]
    public IActionResult Sum(float? x, float? y)
    {
        ViewBag.press = "+";
        ViewBag.x = x;
        ViewBag.y = y;
        ViewBag.result = x + y;
        return View("Calc");
    }
    [HttpGet]
    public IActionResult Sub()
    {
        ViewBag.press = "-";
        return View("Calc");
    }

    [HttpPost]
    public IActionResult Sub(float? x, float? y)
    {
        ViewBag.press = "-";
        ViewBag.x = x;
        ViewBag.y = y;
        ViewBag.result = x - y;
        return View("Calc");
    }
    [HttpGet]
    public IActionResult Mul()
    {
        ViewBag.press = "*";
        return View("Calc");
    }

    [HttpPost]
    public IActionResult Mul(float? x, float? y)
    {
        ViewBag.press = "*";
        ViewBag.x = x;
        ViewBag.y = y;
        ViewBag.result = x * y;
        return View("Calc");
    }
    [HttpGet]
    public IActionResult Div()
    {
        ViewBag.press = "/";
        return View("Calc");
    }

    [HttpPost]
    public IActionResult Div(float? x, float? y)
    {
        ViewBag.press = "+";
        ViewBag.x = x;
        ViewBag.y = y;
        ViewBag.result = x/y;
        return View("Calc");
    }
}