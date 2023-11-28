using Microsoft.AspNetCore.Identity;

namespace lab3b.Models;

public class RoleViewModel
{
    public string? errorMessage = null;
    public bool isActionSuccess = false;
    public List<IdentityRole>? roleList = null;

}