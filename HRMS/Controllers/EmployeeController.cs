using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Searches;
using HRMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers;

public class EmployeeController : BaseCrudController<Employee, EmployeeSearch, EmployeeInsert, EmployeeUpdate>
{
    private readonly IEmployeeRepository EmployeeRepository;

    public EmployeeController(
        IMapper mapper,
        IEmployeeRepository employeeRepository)
        : base(mapper, employeeRepository)
    {
        EmployeeRepository = employeeRepository;
    }

    /// <remarks>Get list of objects using full text search</remarks>
    [HttpGet("search")]
    public virtual async Task<PagedResult<Employee>> Search([FromQuery] EmployeeSearch search)
        => await EmployeeRepository.SearchAsync(search);
}