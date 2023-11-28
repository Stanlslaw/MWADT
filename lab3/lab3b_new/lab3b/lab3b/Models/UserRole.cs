using Microsoft.AspNetCore.Identity;

namespace lab3b.Models;

public class UserRole
{
    public IdentityUser user=null;
    public List<string> rolesList=new List<string>();
    public string GetUserListAsString()
    {
        string output = "";
        foreach (var role in rolesList)
        {
            output += $"{role} ";
        }
        return output;
    }
}