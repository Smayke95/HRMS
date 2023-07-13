using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Searches;
using HRMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers;

public class PositionController : BaseController<Position, PositionSearch>
{
    protected readonly IMapper Mapper;
    private readonly IPositionRepository PositionRepository;

    public PositionController(
        IMapper mapper,
        IPositionRepository positionRepository
        ) : base(positionRepository)
    {
        Mapper = mapper;
        PositionRepository = positionRepository;
    }

    [HttpPost]
    public async Task<Position> Insert([FromBody] PositionInsert position)
        => await PositionRepository.InsertAsync(Mapper.Map<Position>(position));

    [HttpPut("{id}")]
    public async Task<Position> Update(int id, [FromBody] PositionUpdate position)
        => await PositionRepository.UpdateAsync(Mapper.Map<Position>(position, opt => opt.AfterMap((src, dest) => dest.Id = id)));

    [HttpDelete("{id}")]
    public async Task<bool> Delete(int id)
        => await PositionRepository.DeleteAsync(id);
}