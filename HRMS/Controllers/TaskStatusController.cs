using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models.Searches;
using HRMS.Models;
using TaskStatus = HRMS.Core.Models.TaskStatus;

namespace HRMS.Controllers;

public class TaskStatusController : BaseCrudController<TaskStatus, TaskStatusSearch, TaskStatusInsert, TaskStatusUpdate>
{
    public TaskStatusController(IMapper mapper, ITaskStatusRepository taskStatusRepository) : base(mapper, taskStatusRepository) { }
}