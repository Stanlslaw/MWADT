using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();
string parmA, parmB;

//ex1
app.MapGet("/api/ssl", async (context) =>
{
    var req = context.Request;
    var res = context.Response;
    parmA = req.Query["parmA"];
    parmB = req.Query["parmB"];

    res.Headers.ContentType = "text/plain";
    res.Headers.ContentEncoding = "utf-8";
    await res.WriteAsync($"GET-Http-SSL:ParmA = {parmA},ParmB = {parmB}");
});
//ex2
app.MapPost("/api/ssl", async (context) =>
{
    var req = context.Request;
    var res = context.Response;
    parmA = req.Query["parmA"];
    parmB = req.Query["parmB"];

    res.Headers.ContentType = "text/plain";
    res.Headers.ContentEncoding = "utf-8";
   await res.WriteAsync($"POST-Http-SSL:ParmA = {parmA},ParmB = {parmB}");
});
//ex3
app.MapPut("/api/ssl", async (context) =>
{
    var req = context.Request;
    var res = context.Response;
    parmA = req.Query["parmA"];
    parmB = req.Query["parmB"];

    res.Headers.ContentType = "text/plain";
    res.Headers.ContentEncoding = "utf-8";
   await res.WriteAsync($"PUT-Http-SSL:ParmA = {parmA},ParmB = {parmB}");
});
//ex4
app.MapPost("/api/sumex4", async (context) =>
    {
        var res = context.Response;
        var req = context.Request;
        using StreamReader reader = new StreamReader(req.Body);
        string data = await reader.ReadToEndAsync();
        JObject jsonObject = JObject.Parse(data);
        res.ContentType = "text/plain";
        res.Headers.ContentEncoding = "utf-8";
        int result = Convert.ToInt32(jsonObject["num1"]) + Convert.ToInt32(jsonObject["num2"]);
        await res.WriteAsync(result.ToString());
    }
);
//ex5
app.MapMethods("/api/mulex5", new []{"GET","POST"},
    async (context) =>
    {
        var res = context.Response;
        var req = context.Request;
        if (req.Method == HttpMethods.Get)
        {
            res.ContentType = "text/html";
            res.Headers.ContentEncoding = "utf-8";

            var htmlSumForm =await File.ReadAllTextAsync("wwwroot/mulex5.html");
            await res.WriteAsync(htmlSumForm);
        }
        if (req.Method == HttpMethods.Post)
        {
            int parm1 = Int32.Parse(req.Form["parm1"]);
            int parm2 = Int32.Parse(req.Form["parm2"]);
            res.Headers.ContentEncoding = "utf-8";
            await res.WriteAsync($"{parm1 * parm2}");
        }
    });
//ex6
app.MapMethods("/api/mulex6", new []{"GET","POST"},
    async (context) =>
    {
        var res = context.Response;
        var req = context.Request;
        if (req.Method == HttpMethods.Get)
        {
            res.ContentType = "text/html";
            res.Headers.ContentEncoding = "utf-8";

            var htmlSumForm =await File.ReadAllTextAsync("wwwroot/mulex6.html");
            await res.WriteAsync(htmlSumForm);
        }
        if (req.Method == HttpMethods.Post)
            {
                int parm1 = Int32.Parse(req.Query["parm1"]);
                int parm2 = Int32.Parse(req.Query["parm2"]);
                res.Headers.ContentEncoding = "utf-8";
                await res.WriteAsync($"{parm1 * parm2}");
            }
    });

app.Run();