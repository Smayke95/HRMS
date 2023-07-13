using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Searches;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers;

public class EmployeeController : BaseController<Employee, EmployeeSearch>
{
    private readonly IEmployeeRepository EmployeeRepository;

    public EmployeeController(IEmployeeRepository employeeRepository) : base(employeeRepository)
    {
        EmployeeRepository = employeeRepository;
    }

    [HttpGet("search")]
    public virtual async Task<PagedResult<Employee>> Search([FromQuery] EmployeeSearch search)
        => await EmployeeRepository.SearchAsync(search);
}