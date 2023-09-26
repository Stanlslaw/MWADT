using Microsoft.EntityFrameworkCore;
using Phonebook.Models.Dict;

var builder = WebApplication.CreateBuilder(args);
string SqlConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<PhoneBookDb>(options => options.UseSqlServer(SqlConnectionString));
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