using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Searches;

namespace HRMS.Controllers;

public class EmployeeController : BaseController<Employee, EmployeeSearch>
{
    public EmployeeController(IEmployeeRepository employeeRepository) : base(employeeRepository) { }
}