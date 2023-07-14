using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Searches;
using HRMS.Models;

namespace HRMS.Controllers;

public class EmployeePositionController : BaseCrudController<EmployeePosition, EmployeePositionSearch, EmployeePositionInsert, EmployeePositionUpdate>
{
    public EmployeePositionController(IMapper mapper, IEmployeePositionRepository employeePositionRepository) : base(mapper, employeePositionRepository) { }
}