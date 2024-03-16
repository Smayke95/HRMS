using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Searches;
using HRMS.Models;

namespace HRMS.Controllers;

public class ProjectController(IMapper mapper, IProjectRepository projectRepository) : BaseCrudController<Project, ProjectSearch, ProjectInsertUpdate, ProjectInsertUpdate>(mapper, projectRepository) { }