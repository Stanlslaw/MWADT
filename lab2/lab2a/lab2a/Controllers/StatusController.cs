using Microsoft.AspNetCore.Mvc;

namespace lab2a.Controllers;

public class StatusController:Controller
{
    private protected Random random = new Random();
    public IActionResult S200()
    {
        return StatusCode(random.Next(200, 299));
    }
    public IActionResult S300()
    {
        return StatusCode(random.Next(300, 399));
    }
    public IActionResult S500()
    {
        return StatusCode(random.Next(500, 599));
    }
}