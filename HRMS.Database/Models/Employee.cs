using HRMS.Database.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Database.Models;

[Table("Employees")]
public class Employee
{
    [Key]
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string MaidenName { get; set; } = string.Empty;

    public string ParentName { get; set; } = string.Empty;

    public Gender Gender { get; set; }

    public string RegistrationNumber { get; set; } = string.Empty;

    public string PersonalIdentificationNumber { get; set; } = string.Empty;

    public string WorkerCode { get; set; } = string.Empty;

    public DateTime BirthDate { get; set; }

    [ForeignKey("BirthPlace")]
    public int? BirthPlaceId { get; set; }
    public virtual City? BirthPlace { get; set; }

    public string Address { get; set; } = string.Empty;

    [ForeignKey("City")]
    public int? CityId { get; set; }
    public virtual City? City { get; set; }

    [ForeignKey("Citizenship")]
    public int? CitizenshipId { get; set; }
    public virtual Country? Citizenship { get; set; }

    public string Image { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string Mobile { get; set; } = string.Empty;

    public string OfficePhone { get; set; } = string.Empty;

    public string Profession { get; set; } = string.Empty;

    [ForeignKey("Education")]
    public int? EducationId { get; set; }
    public virtual Education? Education { get; set; }

    public int PreviousLOSYears { get; set; }

    public int PreviousLOSMonths { get; set; }

    public string BankAccount { get; set; } = string.Empty;

    public string Note { get; set; } = string.Empty;

    public DateTime CreateDate { get; set; }



    // Relations
    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
    public virtual ICollection<EmployeePosition> EmployeePositions { get; set; } = new List<EmployeePosition>();
    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
    public virtual ICollection<EmployeeRole> Roles { get; set; } = new List<EmployeeRole>();
    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
    public virtual ICollection<TaskComment> TaskComments { get; set; } = new List<TaskComment>();
}