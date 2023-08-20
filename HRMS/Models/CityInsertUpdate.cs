using System.ComponentModel.DataAnnotations;

namespace HRMS.Models;

public class CityInsertUpdate
{
    [Required]
    public string Name { get; set; } = string.Empty;

    public string ZipCode { get; set; } = string.Empty;

    [Required]
    public int? CountryId { get; set; }
}