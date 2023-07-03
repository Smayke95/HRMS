using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Searches;

namespace HRMS.Controllers;

public class ProjectController : BaseController<Project, BaseSearch>
{
    public ProjectController(IProjectRepository projectRepository) : base(projectRepository) { }
}