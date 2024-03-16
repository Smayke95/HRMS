using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Searches;
using HRMS.Models;

namespace HRMS.Controllers;

public class TaskTypeController(IMapper mapper, ITaskTypeRepository taskTypeRepository) : BaseCrudController<TaskType, TaskTypeSearch, TaskTypeInsertUpdate, TaskTypeInsertUpdate>(mapper, taskTypeRepository) { }