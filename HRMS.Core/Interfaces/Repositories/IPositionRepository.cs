using HRMS.Core.Models;
using HRMS.Core.Models.Searches;

namespace HRMS.Core.Interfaces.Repositories;

public interface IPositionRepository : IBaseRepository<Position, PositionSearch>
{
    Task<PagedResult<Position>> SearchAsync(PositionSearch search);
}