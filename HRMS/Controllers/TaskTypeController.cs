using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Searches;
using HRMS.Models;

namespace HRMS.Controllers;

public class TaskTypeController : BaseCrudController<TaskType, TaskTypeSearch, TaskTypeInsertUpdate, TaskTypeInsertUpdate>
{
    public TaskTypeController(IMapper mapper, ITaskTypeRepository taskTypeRepository) : base(mapper, taskTypeRepository) { }
}