using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Requests;
using HRMS.Core.Models.Searches;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers;

public class DepartmentController : BaseController<Department, DepartmentSearch>
{
    public DepartmentController(IDepartmentRepository departmentRepository) : base(departmentRepository) { }

    [HttpPost]
    public async Task<IActionResult> Insert([FromBody] DepartmentInsertRequest department)
        => Ok(department);
}