using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Database.Models;

[Table("Cities")]
public class City
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string ZipCode { get; set; } = string.Empty;

    [ForeignKey("Country")]
    public int CountryId { get; set; }
    public virtual Country? Country { get; set; }
}