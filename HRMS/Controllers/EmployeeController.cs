using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Interfaces.Services;
using HRMS.Core.Models;
using HRMS.Core.Models.Searches;
using HRMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers;

public class EmployeeController : BaseCrudController<Employee, EmployeeSearch, EmployeeInsertUpdate, EmployeeInsertUpdate>
{
    private readonly IEmployeeService EmployeeService;

    public EmployeeController(
        IMapper mapper,
        IEmployeeRepository employeeRepository,
        IEmployeeService employeeService)
        : base(mapper, employeeRepository)
    {
        EmployeeService = employeeService;
    }

    /// <remarks>Insert new object</remarks>
    [HttpPost]
    public override async Task<Employee> Insert([FromBody] EmployeeInsertUpdate insert)
        => await EmployeeService.InsertAsync(Mapper.Map<Employee>(insert));
}