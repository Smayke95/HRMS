using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models.Searches;
using TaskStatus = HRMS.Database.Models.TaskStatus;

namespace HRMS.Database.Repositories;

public class TaskStatusRepository(Context context, IMapper mapper) : BaseRepository<TaskStatus, Core.Models.TaskStatus, TaskStatusSearch>(context, mapper), ITaskStatusRepository
{
    protected override IQueryable<TaskStatus> AddInclude(IQueryable<TaskStatus> query, TaskStatusSearch? search = null)
    {
        if (search is null)
            return base.AddInclude(query, search);

        if (!string.IsNullOrWhiteSpace(search.Name))
            query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));

        return query;
    }
}