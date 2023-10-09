global using DataContext = AppDataBaseContext;//AppJsonContext //AppDataBaseContext
global using DataContextInterfaces = AppDataBaseContext.Interfaces;//AppJsonContext.Interfaces //AppDataBaseContext.Interfaces
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Json Service
//builder.Services.AddSingleton<DataContextInterfaces.IPhoneDictionary>(new DataContext.PhoneDictionary(@"C:\Users\stass\Desktop\СТРВП\MWADT\lab6\lab6\lab6\wwwroot\PhonesBookData.json"));

//SqlService
builder.Services.AddScoped<AppDataBaseContext.PhoneDictionary,AppDataBaseContext.PhoneDictionary>();
builder.Services.AddDbContext<AppDataBaseContext.PhoneDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")),ServiceLifetime.Scoped);



var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
