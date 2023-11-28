using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using lab3b.Data;
using lab7.Models;
using lab7.StaticData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;
        }
    )
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
           
    foreach (var role in Roles.roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            var result = await roleManager.CreateAsync(new IdentityRole(role));
            if (result.Succeeded)
            {
                continue;
            }
        }
    }
}

using (var scope= app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
         

    foreach (var user in StaticData.users)
    {   
        if (await userManager.FindByEmailAsync(user.Email)==null)
        {
            var newUser = new IdentityUser();
            newUser.Email = user.Email;
            newUser.UserName = user.Email;
            newUser.EmailConfirmed = true;        
                    
            var result = await userManager.CreateAsync(newUser, user.Password);
            if (result.Succeeded)
            {
                await  userManager.AddToRolesAsync(newUser,user.Roles);
            }
            else
            {
                Console.Write(result.Errors);
                throw new Exception(result.Errors.ToString());
            }
                   
        }
        else
        {
          var curUser=await  userManager.FindByEmailAsync(user.Email);
          var token = await userManager.GeneratePasswordResetTokenAsync(curUser);
          var result = await userManager.ResetPasswordAsync(curUser, token, user.Password);
        }
       
    }
}

app.Run();