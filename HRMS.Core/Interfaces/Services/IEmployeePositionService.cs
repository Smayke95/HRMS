using HRMS.Core.Models;
using HRMS.Core.Models.Enums;

namespace HRMS.Core.Interfaces.Services;

public interface IEmployeePositionService
{
    Task<IEnumerable<EmploymentStatus>> AllowedActionsAsync(int id);
    Task<EmployeePosition> InsertAsync(EmployeePosition employeePosition);
    Task<EmployeePosition> UpdateAsync(EmployeePosition employeePosition);
    Task<bool> ActivateAsync(int id);
    Task<bool> DeactivateAsync(int id);
    Task<bool> DeleteAsync(int id);
}