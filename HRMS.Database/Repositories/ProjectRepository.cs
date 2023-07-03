using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models.Searches;
using HRMS.Database.Models;

namespace HRMS.Database.Repositories;

public class ProjectRepository : BaseRepository<Project, Core.Models.Project, BaseSearch>, IProjectRepository
{
    public ProjectRepository(Context context, IMapper mapper) : base(context, mapper) { }
}