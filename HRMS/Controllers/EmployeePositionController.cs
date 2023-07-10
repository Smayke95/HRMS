using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Searches;

namespace HRMS.Controllers;

public class EmployeePositionController : BaseController<EmployeePosition, EmployeePositionSearch>
{
    public EmployeePositionController(IEmployeePositionRepository employeePositionRepository) : base(employeePositionRepository) { }
}