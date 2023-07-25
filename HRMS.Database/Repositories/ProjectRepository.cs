using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models.Searches;
using HRMS.Database.Models;

namespace HRMS.Database.Repositories;

public class ProjectRepository : BaseRepository<Project, Core.Models.Project, ProjectSearch>, IProjectRepository
{
    public ProjectRepository(Context context, IMapper mapper) : base(context, mapper) { }

    protected override IQueryable<Project> AddInclude(IQueryable<Project> query, ProjectSearch? search = null)
    {
        if (search is null)
            return base.AddInclude(query, search);

        if (!string.IsNullOrWhiteSpace(search.Name))
            query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));       

        return query;
    }
}