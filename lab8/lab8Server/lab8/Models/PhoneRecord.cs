using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace lab8.Models;

public class PhoneRecord
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
}