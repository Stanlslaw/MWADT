global using Microsoft.AspNetCore.SignalR;
using WebSockets;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();

app.MapHub<WebHub>("/ws");

app.Run();