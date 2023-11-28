using Microsoft.AspNetCore.Identity;

namespace lab3b.Models;

public class UserRolesViewModel
{
    public string? errorMessage = null;
    public bool isActionSuccess = false;
    public List<IdentityUser>? userList = null;
    public List<IdentityRole>? rolesList = null;
    public List<UserRole>? userRoles = null;
}