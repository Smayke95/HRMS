using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Database.Models;

[Table("PayGrades")]
public class PayGrade
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")]
    public decimal MinAmount { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal MaxAmount { get; set; }



    // Relations
    public virtual ICollection<Position> Positions { get; set; } = new List<Position>();
}