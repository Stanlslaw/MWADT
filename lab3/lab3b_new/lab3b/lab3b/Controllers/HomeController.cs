using System.Collections;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using lab3b.Models;
using lab7.StaticData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;

namespace lab3b.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public HomeController(ILogger<HomeController> logger,
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _roleManager = roleManager;
        _userManager = userManager;
    }
    
    public IActionResult Index()
    {
        return View();
    }
    [Authorize]
    public IActionResult Privacy()
    {
        return View();
    }
    [Authorize(Roles = "Administrator")]
    public IActionResult Admin()
    {
        return View();
    }

    [HttpGet]
    [HttpPost]
    public async Task<IActionResult> AddNewUser(string? email, string? password)
    {
        var userModel = new UserViewModel();
        userModel.userList = _userManager.Users.ToList();
        if (HttpContext.Request.Method == HttpMethods.Get)
        {
            return View(userModel);
        }
        if (email == null || password == null)
        {
            userModel.errorMessage = "Одно из полей не заполнено";
            return View(userModel);
        }
        if (_userManager.FindByEmailAsync(email).Result!=null)
        {
            userModel.errorMessage = "Данный пользователь уже существует";
            return View(userModel);
        }
        
        var newUser = new IdentityUser(){Email = email,UserName = email};
        await _userManager.CreateAsync(newUser, password);
        userModel.isActionSuccess = true;
        userModel.userList = _userManager.Users.ToList();
        return View(userModel);
    }
    [HttpGet]
    [HttpPost]
    public async Task<IActionResult> DeleteUser(string userId)
    {
        var userModel = new UserViewModel();
        userModel.userList = _userManager.Users.ToList();
        if (HttpContext.Request.Method == HttpMethods.Get)
        {
            return View(userModel);
        }
        if (await _userManager.FindByIdAsync(userId) == null)
        {
            userModel.errorMessage = "Пользователь не найден";
            return View(userModel);
        }
        if (_userManager.FindByIdAsync(userId).Result.Email == "admin@belstu.by")
        {
            userModel.errorMessage = "Пользователя администратора удалить нельзя";
            return View(userModel);
        }
        await  _userManager.DeleteAsync(await _userManager.FindByIdAsync(userId));
        userModel.isActionSuccess = true;
        userModel.userList=_userManager.Users.ToList();
        return View(userModel);
    }
    [HttpGet]
    [HttpPost]
    public async Task<IActionResult> AddNewRole(string? roleName)
    {
        var roleModel = new RoleViewModel();
        roleModel.roleList = _roleManager.Roles.ToList();
        if (HttpContext.Request.Method == HttpMethods.Get)
        {
            return View(roleModel);
        }
        if (roleName == null)
        {
            roleModel.errorMessage = "Поле роли пустое";
            return View(roleModel);
        }
        if ( await _roleManager.RoleExistsAsync(roleName))
        {
            roleModel.errorMessage = "Данная роль уже существует";
            return View(roleModel);
        }
        await _roleManager.CreateAsync(new IdentityRole(roleName));
        roleModel.isActionSuccess = true;
        roleModel.roleList = _roleManager.Roles.ToList();
        return View(roleModel);
    }
    [HttpGet]
    [HttpPost]
    public async Task<IActionResult> DeleteRole(string roleId)
    {
        var roleModel = new RoleViewModel();
        roleModel.roleList = _roleManager.Roles.ToList();
        if (HttpContext.Request.Method == HttpMethods.Get)
        {
            return View(roleModel);
        }
        var role = await _roleManager.FindByIdAsync(roleId);
        if (role == null)
        {
            roleModel.errorMessage = "Роль не найдена";
            return View(roleModel);
        }

        if (role.Name == "Administrator")
        {
            roleModel.errorMessage = "Роль администратора удалить нельзя";
            return View(roleModel);
        }
            var usersInRole = await _userManager.GetUsersInRoleAsync(role.Name);
            foreach (var user in usersInRole)
            {
                await _userManager.RemoveFromRoleAsync(user, role.Name);
            }
            await _roleManager.DeleteAsync(role);
            roleModel.isActionSuccess = true;
            roleModel.roleList = _roleManager.Roles.ToList();
        return View(roleModel);
    }
    [HttpGet]
    [HttpPost]
    public async Task<IActionResult> AssignRolesToUser(string? roleName, string? userEmail)
    {
        var userRolesModel = new UserRolesViewModel();
        userRolesModel.userList = _userManager.Users.ToList();
        userRolesModel.rolesList = _roleManager.Roles.ToList();
        userRolesModel.userRoles = new List<UserRole>();
        foreach (var user in userRolesModel.userList)
        {
            userRolesModel.userRoles.Add(new UserRole(){user = user,rolesList =_userManager.GetRolesAsync(user).Result.ToList()});
        }
        if (HttpContext.Request.Method == HttpMethods.Get)
        {
            return View(userRolesModel);
        }

        if (roleName == null || userEmail == null)
        {
            userRolesModel.errorMessage = "Один из параметров не выбран";
        }
        await _userManager.AddToRoleAsync(await _userManager.FindByEmailAsync(userEmail), roleName);
        userRolesModel.userRoles = new List<UserRole>();
        foreach (var user in userRolesModel.userList)
        {
            userRolesModel.userRoles.Add(new UserRole(){user = user,rolesList =_userManager.GetRolesAsync(user).Result.ToList()});
        }
        userRolesModel.userList = _userManager.Users.ToList();
        userRolesModel.rolesList = _roleManager.Roles.ToList();
        userRolesModel.isActionSuccess = true;
        return View(userRolesModel);
    }
    [HttpGet]
    [HttpPost]
    public async Task<IActionResult> RemoveRolesFromUser(string? roleName, string? userEmail)
    {
        var userRolesModel = new UserRolesViewModel();
        userRolesModel.userList = _userManager.Users.ToList();
        userRolesModel.rolesList = _roleManager.Roles.ToList();
        userRolesModel.userRoles = new List<UserRole>();
        foreach (var user in userRolesModel.userList)
        {
            userRolesModel.userRoles.Add(new UserRole(){user = user,rolesList =_userManager.GetRolesAsync(user).Result.ToList()});
        }
        if (HttpContext.Request.Method == HttpMethods.Get)
        {
            return View(userRolesModel);
        }
        if (roleName == null || userEmail == null)
        {
            userRolesModel.errorMessage = "Один из параметров не выбран";
        }
        await _userManager.RemoveFromRoleAsync(await _userManager.FindByEmailAsync(userEmail), roleName);
        userRolesModel.userRoles = new List<UserRole>();
        foreach (var user in userRolesModel.userList)
        {
            userRolesModel.userRoles.Add(new UserRole(){user = user,rolesList =_userManager.GetRolesAsync(user).Result.ToList()});
        }
        userRolesModel.userList = _userManager.Users.ToList();
        userRolesModel.rolesList = _roleManager.Roles.ToList();
        userRolesModel.isActionSuccess = true;
        return View(userRolesModel);
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}