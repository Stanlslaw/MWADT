using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace lab5a.Controllers;

public class CResearchController:Controller
{
    [HttpGet]
    [HttpPost]
    [Route("{controller}/")]
    [Route("{controller}/C01")]
    public async Task C01()
    {
        StringBuilder res = new StringBuilder();
        string method = Request.Method;
        var queries = Request.Query.ToArray();
        string Uri = Request.Path;
        var headers = Request.Headers.ToArray();
        var bodyReader = new StreamReader(Request.Body, Encoding.UTF8);
        var body = await bodyReader.ReadToEndAsync();

        res.Append($"<b>Method</b>: {method} </br> <b>Queries</b>: </br>");
        foreach (var item in queries)
        {
            res.Append($"   <b>key</b>: {item.Key} <b>value</b>: {item.Value} </br>");
        }
        res.Append($"</br> <b>uri</b>: {Uri} </br> <b>headers</b>: </br>");
        foreach (var item in headers)
        {
            res.Append($"   <b>key</b>: {item.Key} <b>value</b>: {item.Value} </br>");
        }

        res.Append($"<b>body</b>: {body}");
        Response.ContentType = "text/html;charset=utf-8";
        await Response.WriteAsync(res.ToString());
    }

    [HttpGet]
    [HttpPost]
    [Route("{controller}/C02")]
    public async Task C02()
    {
        StringBuilder res = new StringBuilder();
        var headers = Request.Headers.ToArray();
        var bodyReader = new StreamReader(Request.Body, Encoding.UTF8);
        var body = await bodyReader.ReadToEndAsync();
        string statusCode = Response.StatusCode.ToString();

        res.Append($"</br> <b>status code</b>: {statusCode} </br> <b>headers</b>: </br>");
        foreach (var item in headers)
        {
            res.Append($"   <b>key</b>: {item.Key} <b>value</b>: {item.Value} </br>");
        }

        res.Append($"<b>body</b>: {body}");
        Response.ContentType = "text/html;charset=utf-8";
        await Response.WriteAsync(res.ToString());
    }
}