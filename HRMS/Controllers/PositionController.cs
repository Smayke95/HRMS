using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Searches;
using HRMS.Models;

namespace HRMS.Controllers;

public class PositionController : BaseCrudController<Position, PositionSearch, PositionInsert, PositionUpdate>
{
    public PositionController(IMapper mapper, IPositionRepository positionRepository) : base(mapper, positionRepository) { }
}