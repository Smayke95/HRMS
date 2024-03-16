using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models.Searches;
using HRMS.Database.Models;

namespace HRMS.Database.Repositories;

public class ProjectRepository(Context context, IMapper mapper) : BaseRepository<Project, Core.Models.Project, ProjectSearch>(context, mapper), IProjectRepository
{
    protected override IQueryable<Project> AddInclude(IQueryable<Project> query, ProjectSearch? search = null)
    {
        if (search is null)
            return base.AddInclude(query, search);

        if (!string.IsNullOrWhiteSpace(search.Name))
            query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));

        return query;
    }
}