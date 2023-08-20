using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models.Searches;
using HRMS.Models;
using TaskComment = HRMS.Core.Models.TaskComment;

namespace HRMS.Controllers;

public class TaskCommentController : BaseCrudController<TaskComment, BaseSearch, TaskCommentInsertUpdate, TaskCommentInsertUpdate>
{
    public TaskCommentController(IMapper mapper, ITaskCommentRepository taskStatusRepository) : base(mapper, taskStatusRepository) { }
}