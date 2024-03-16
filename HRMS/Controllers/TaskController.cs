using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Searches;
using HRMS.Models;
using Microsoft.AspNetCore.Mvc;
using Task = HRMS.Core.Models.Task;

namespace HRMS.Controllers;

public class TaskController(
    IMapper mapper,
    ITaskRepository taskRepository)
    : BaseCrudController<Task, TaskSearch, TaskInsertUpdate, TaskInsertUpdate>(mapper, taskRepository)
{
    private readonly ITaskRepository TaskRepository = taskRepository;

    /// <remarks>Get list of objects using full text search</remarks>
    [HttpGet("search")]
    public async Task<PagedResult<Task>> Search([FromQuery] TaskSearch search)
        => await TaskRepository.SearchAsync(search);
}