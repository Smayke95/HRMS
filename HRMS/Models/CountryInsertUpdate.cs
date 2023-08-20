using System.ComponentModel.DataAnnotations;

namespace HRMS.Models;

public class CountryInsertUpdate
{
    [Required]
    public string Name { get; set; } = string.Empty;
}