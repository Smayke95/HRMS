using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Searches;
using HRMS.Models;

namespace HRMS.Controllers;

public class DepartmentController(IMapper mapper, IDepartmentRepository departmentRepository) : BaseCrudController<Department, DepartmentSearch, DepartmentInsertUpdate, DepartmentInsertUpdate>(mapper, departmentRepository) { }