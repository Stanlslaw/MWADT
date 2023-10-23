using Microsoft.AspNetCore.Mvc;

namespace lab5a.Controllers;

// [Route("{controller}")]
// [Route("V2/{controller}")]
// [Route("V3/{controller}/X")]
public class MResearchController : Controller
{
    [Route("/")]
    [Route("{controller}/M01/1")]
    [Route("{controller}/M01")]
    [Route("{controller}")]
    [Route("V2/{controller}/M01")]
    [Route("V3/{controller}/X/M01")]
    [HttpGet]
    public string M01()
    {
        return "GET:M01";
    }
    [Route("V2")]
    [Route("V2/{controller}/M02")]
    [Route("{controller}/M02")]
    [Route("V3/{controller}/X/M02")]
    [HttpGet]
    public string M02()
    {
        return "GET:M02";
    }
    [Route("V3")]
    [Route("V3/{controller}/X/")]
    [Route("V3/{controller}/X/M03")]
    [HttpGet]
    public string M03()
    {
        return "GET:M03";
    }
    [Route("{controller}/MXX")]
    [HttpGet]
    public string MXX()
    {
        return "MXX";
    }
}