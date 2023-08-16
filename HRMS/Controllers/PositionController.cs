using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Searches;
using HRMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers;

public class PositionController : BaseCrudController<Position, PositionSearch, PositionInsertUpdate, PositionInsertUpdate>
{
    private readonly IPositionRepository PositionRepository;

    public PositionController(
        IMapper mapper,
        IPositionRepository positionRepository)
        : base(mapper, positionRepository)
    {
        PositionRepository = positionRepository;
    }

    /// <remarks>Get list of objects using full text search</remarks>
    [HttpGet("search")]
    public async Task<PagedResult<Position>> Search([FromQuery] PositionSearch search)
        => await PositionRepository.SearchAsync(search);
}