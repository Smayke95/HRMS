using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models.Searches;
using HRMS.Models;
using TaskStatus = HRMS.Core.Models.TaskStatus;

namespace HRMS.Controllers;

public class TaskStatusController(IMapper mapper, ITaskStatusRepository taskStatusRepository) : BaseCrudController<TaskStatus, TaskStatusSearch, TaskStatusInsertUpdate, TaskStatusInsertUpdate>(mapper, taskStatusRepository) { }