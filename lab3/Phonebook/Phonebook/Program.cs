var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Dict/Error");
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/Dict/Error","?code={0}");
app.UseStaticFiles();
app.UseDefaultFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dict}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();