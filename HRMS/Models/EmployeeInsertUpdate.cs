using HRMS.Core.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Models;

public class EmployeeInsertUpdate
{
    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;

    public string MaidenName { get; set; } = string.Empty;

    public string ParentName { get; set; } = string.Empty;

    [Required]
    public Gender Gender { get; set; }

    [Required]
    public string RegistrationNumber { get; set; } = string.Empty;

    public string PersonalIdentificationNumber { get; set; } = string.Empty;

    public string WorkerCode { get; set; } = string.Empty;

    [Required]
    public DateTime? BirthDate { get; set; }

    public int? BirthPlaceId { get; set; }

    public string Address { get; set; } = string.Empty;

    public int? CityId { get; set; }

    public int? CitizenshipId { get; set; }

    public string Image { get; set; } = string.Empty;

    [Required]
    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string Mobile { get; set; } = string.Empty;

    public string OfficePhone { get; set; } = string.Empty;

    public string Profession { get; set; } = string.Empty;

    public int? EducationId { get; set; }

    public int PreviousLOSYears { get; set; }

    public int PreviousLOSMonths { get; set; }

    public string BankAccount { get; set; } = string.Empty;

    public string Note { get; set; } = string.Empty;
}