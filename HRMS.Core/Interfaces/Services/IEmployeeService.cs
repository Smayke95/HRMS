using HRMS.Core.Models;

namespace HRMS.Core.Interfaces.Services;

public interface IEmployeeService
{
    Task<Employee> InsertAsync(Employee employee);
}