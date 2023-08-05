using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models.Searches;
using HRMS.Database.Models;

namespace HRMS.Database.Repositories;

public class TaskTypeRepository : BaseRepository<TaskType, Core.Models.TaskType, TaskTypeSearch>, ITaskTypeRepository
{
    public TaskTypeRepository(Context context, IMapper mapper) : base(context, mapper) { }

    protected override IQueryable<TaskType> AddInclude(IQueryable<TaskType> query, TaskTypeSearch? search = null)
    {
        if (search is null)
            return base.AddInclude(query, search);

        if (!string.IsNullOrWhiteSpace(search.Name))
            query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));

        return query;
    }
}