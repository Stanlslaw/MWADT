using System.Reflection;
namespace lab7.Models;

public static class Roles
{
    public const string Administrator = "Administrator";
    public const string Guest = "Guest";
    public const string Employer = "Employer";
    public static List<string> roles=new(){Administrator,Employer,Guest};

   
}