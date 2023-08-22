using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Searches;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Database.Repositories;

public class TaskCommentRepository : BaseRepository<Models.TaskComment, TaskComment, TaskCommentSearch>, ITaskCommentRepository
{
    public TaskCommentRepository(Context context, IMapper mapper) : base(context, mapper) { }

    public override async Task<TaskComment> GetAsync(int id)
    {
        var isNew = id == 0;

        if (!isNew)
        {
            var entity = await Context
                .TaskComments
                .Include(x => x.Task)
                .Include(x => x.Employee)
                .SingleOrDefaultAsync(x => x.Id == id);

            return Mapper.Map<TaskComment>(entity);
        }

        return new TaskComment();
    }

    protected override IQueryable<Models.TaskComment> AddInclude(IQueryable<Models.TaskComment> query, TaskCommentSearch? search = null)       
    {
        if (search is null)
            return base.AddInclude(query, search);

        query = query
            .Include(x => x.Employee)
            .Include(x => x.Task)
            .OrderBy(x=>x.Time);

        if (search.TaskId != null)
            query = query.Where(x => x.TaskId == search.TaskId);

        return query;
    }
}