using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Database.Models;

[Table("Countries")]
public class Country
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;



    // Relations
    public virtual ICollection<City> Cities { get; set; } = new List<City>();
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}