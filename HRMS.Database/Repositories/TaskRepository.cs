using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models.Searches;

namespace HRMS.Database.Repositories;

public class TaskRepository : BaseRepository<Models.Task, Core.Models.Task, BaseSearch>, ITaskRepository
{
    public TaskRepository(Context context, IMapper mapper) : base(context, mapper) { }
}