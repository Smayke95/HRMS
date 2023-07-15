using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Interfaces.Services;
using HRMS.Core.Models;
using HRMS.Core.Models.Searches;
using HRMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers;

public class EmployeeController : BaseCrudController<Employee, EmployeeSearch, EmployeeInsert, EmployeeUpdate>
{
    private readonly IEmployeeRepository EmployeeRepository;
    private readonly IEmployeeService EmployeeService;

    public EmployeeController(
        IMapper mapper,
        IEmployeeRepository employeeRepository,
        IEmployeeService employeeService)
        : base(mapper, employeeRepository)
    {
        EmployeeRepository = employeeRepository;
        EmployeeService = employeeService;
    }

    /// <remarks>Get list of objects using full text search</remarks>
    [HttpGet("search")]
    public async Task<PagedResult<Employee>> Search([FromQuery] EmployeeSearch search)
        => await EmployeeRepository.SearchAsync(search);

    /// <remarks>Insert new object</remarks>
    [HttpPost]
    public override async Task<Employee> Insert([FromBody] EmployeeInsert insert)
        => await EmployeeService.InsertAsync(Mapper.Map<Employee>(insert));
}