using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models.Searches;
using HRMS.Database.Models;

namespace HRMS.Database.Repositories;

public class EmployeePositionRepository : BaseRepository<EmployeePosition, Core.Models.EmployeePosition, BaseSearch>, IEmployeePositionRepository
{
    public EmployeePositionRepository(Context context, IMapper mapper) : base(context, mapper) { }
}