using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Searches;
using HRMS.Models;

namespace HRMS.Controllers;

public class ProjectController : BaseCrudController<Project, ProjectSearch, ProjectInsertUpdate, ProjectInsertUpdate>
{
    public ProjectController(IMapper mapper, IProjectRepository projectRepository) : base(mapper, projectRepository) { }
}