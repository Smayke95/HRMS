using HRMS.Core.Models.Searches;
using TaskStatus = HRMS.Core.Models.TaskStatus;

namespace HRMS.Core.Interfaces.Repositories;

public interface ITaskStatusRepository : IBaseRepository<TaskStatus, TaskStatusSearch> { }