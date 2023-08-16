using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Searches;
using HRMS.Models;

namespace HRMS.Controllers;

public class DepartmentController : BaseCrudController<Department, DepartmentSearch, DepartmentInsertUpdate, DepartmentInsertUpdate>
{
    public DepartmentController(IMapper mapper, IDepartmentRepository departmentRepository) : base(mapper, departmentRepository) { }
}