using HRMS.Core.Models.Searches;
using TaskComment = HRMS.Core.Models.TaskComment;

namespace HRMS.Core.Interfaces.Repositories;

public interface ITaskCommentRepository : IBaseRepository<TaskComment, BaseSearch> { }