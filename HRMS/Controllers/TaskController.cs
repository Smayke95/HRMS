using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Searches;
using HRMS.Models;
using Microsoft.AspNetCore.Mvc;
using Task = HRMS.Core.Models.Task;

namespace HRMS.Controllers;

public class TaskController : BaseCrudController<Task, TaskSearch, TaskInsertUpdate, TaskInsertUpdate>
{
    private readonly ITaskRepository TaskRepository;

    public TaskController(
        IMapper mapper,
        ITaskRepository taskRepository)
        : base(mapper, taskRepository)
    {
        TaskRepository = taskRepository;
    }

    /// <remarks>Get list of objects using full text search</remarks>
    [HttpGet("search")]
    public async Task<PagedResult<Task>> Search([FromQuery] TaskSearch search)
        => await TaskRepository.SearchAsync(search);
}