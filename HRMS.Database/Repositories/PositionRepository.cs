using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models.Searches;
using HRMS.Database.Models;

namespace HRMS.Database.Repositories;

public class PositionRepository : BaseRepository<Position, Core.Models.Position, BaseSearch>, IPositionRepository
{
    public PositionRepository(Context context, IMapper mapper) : base(context, mapper) { }
}