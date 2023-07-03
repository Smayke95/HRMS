using HRMS.Core.Enums.Model;

namespace HRMS.Core.Models;

public class Employee
{
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

    public City BirthPlace { get; set; } = new();

    public string Address { get; set; } = string.Empty;

    public City City { get; set; } = new();

    public Country Citizenship { get; set; } = new();

    public string Image { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string Mobile { get; set; } = string.Empty;

    public string OfficePhone { get; set; } = string.Empty;

    public string Profession { get; set; } = string.Empty;

    public Education Education { get; set; } = new();

    public int PreviousLOSYears { get; set; }

    public int PreviousLOSMonths { get; set; }

    public string BankAccount { get; set; } = string.Empty;

    public string Note { get; set; } = string.Empty;

    public DateTime CreateDate { get; set; }
}