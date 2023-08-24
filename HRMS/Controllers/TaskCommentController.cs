using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Searches;
using HRMS.Models;

namespace HRMS.Controllers;

public class TaskCommentController : BaseCrudController<TaskComment, TaskCommentSearch, TaskCommentInsertUpdate, TaskCommentInsertUpdate>
{
    public TaskCommentController(IMapper mapper, ITaskCommentRepository taskCommentRepository) : base(mapper, taskCommentRepository) { }
}