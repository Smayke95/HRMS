using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Searches;
using HRMS.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.RateLimiting;

namespace HRMS.Controllers;

[Authorize]
[ApiController]
[ExceptionFilter]
[Route("[controller]")]
[EnableRateLimiting("FixedPolicy")]
public abstract class BaseController<T, TSearch> : ControllerBase
    where T : Base
    where TSearch : BaseSearch
{
    private readonly IBaseRepository<T, TSearch> BaseRepository;

    protected BaseController(IBaseRepository<T, TSearch> baseRepository)
    {
        BaseRepository = baseRepository;
    }

    /// <remarks>Get object by Id</remarks>
    [HttpGet("{id}")]
    public virtual async Task<T> Get(int id)
        => await BaseRepository.GetAsync(id);

    /// <remarks>Get list of objects using search</remarks>
    [HttpGet]
    public virtual async Task<PagedResult<T>> GetAll([FromQuery] TSearch search)
        => await BaseRepository.GetAllAsync(search);
}