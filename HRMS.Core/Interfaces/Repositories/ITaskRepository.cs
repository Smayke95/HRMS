using HRMS.Core.Models;
using HRMS.Core.Models.Searches;
using Task = HRMS.Core.Models.Task;

namespace HRMS.Core.Interfaces.Repositories;

public interface ITaskRepository : IBaseRepository<Task, BaseSearch> { }