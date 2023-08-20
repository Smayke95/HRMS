using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Searches;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Database.Repositories;

public class TaskRepository : BaseRepository<Models.Task, Core.Models.Task, TaskSearch>, ITaskRepository
{
    public TaskRepository(Context context, IMapper mapper) : base(context, mapper) { }

    public override async Task<Core.Models.Task> GetAsync(int id)
    {
        var isNew = id == 0;

        if (!isNew)
        {
            var entity = await Context
                .Tasks
                .Include(x => x.Project)
                .Include(x => x.Status)
                .Include(x => x.Type)
                .Include(x => x.Employee)
                .SingleOrDefaultAsync(x => x.Id == id);

            return Mapper.Map<Core.Models.Task>(entity);
        }

        return new Core.Models.Task();
    }

    protected override IQueryable<Models.Task> AddInclude(IQueryable<Models.Task> query, TaskSearch? search = null)
    {
        if (search is null)
            return base.AddInclude(query, search);

        if (!string.IsNullOrWhiteSpace(search.Name))
            query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));

        if (search.IncludeProject)
            query = query.Include(x => x.Project);

        if (search.IncludeStatus)
            query = query.Include(x => x.Status);

        if (search.IncludeType)
            query = query.Include(x => x.Type);

        if (search.IncludeEmployee)
            query = query.Include(x => x.Employee);

        return query;
    }

    public async Task<PagedResult<Core.Models.Task>> SearchAsync(TaskSearch search)
    {
        var result = new PagedResult<Core.Models.Task>();

        if (search is null)
            return result;

        result.Page = search?.Page ?? 1;
        result.PageSize = search?.PageSize ?? 10;

        var tasks = await Context
            .Tasks
            .Where(x => EF.Functions.Contains(x.Name, $"\"{search!.Name}\""))
            .ToListAsync();

        result.Result = Mapper.Map<List<Core.Models.Task>>(tasks);
        return result;
    }
}