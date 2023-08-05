using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models.Searches;
using HRMS.Database.Models;
using TaskStatus = HRMS.Database.Models.TaskStatus;

namespace HRMS.Database.Repositories;

public class TaskStatusRepository : BaseRepository<TaskStatus, Core.Models.TaskStatus, TaskStatusSearch>, ITaskStatusRepository
{
    public TaskStatusRepository(Context context, IMapper mapper) : base(context, mapper) { }

    protected override IQueryable<TaskStatus> AddInclude(IQueryable<TaskStatus> query, TaskStatusSearch? search = null)
    {
        if (search is null)
            return base.AddInclude(query, search);

        if (!string.IsNullOrWhiteSpace(search.Name))
            query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));

        return query;
    }
}