using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Searches;

namespace HRMS.Controllers;

public class PositionController : BaseController<Position, PositionSearch>
{
    public PositionController(IPositionRepository positionRepository) : base(positionRepository) { }
}