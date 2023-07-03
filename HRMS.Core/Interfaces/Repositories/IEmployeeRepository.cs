using HRMS.Core.Models;
using HRMS.Core.Models.Searches;

namespace HRMS.Core.Interfaces.Repositories;

public interface IEmployeeRepository : IBaseRepository<Employee, EmployeeSearch> { }