using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models.Searches;
using HRMS.Database.Models;

namespace HRMS.Database.Repositories;

public class EducationRepository : BaseRepository<Education, Core.Models.Education, BaseSearch>, IEducationRepository
{
    public EducationRepository(Context context, IMapper mapper) : base(context, mapper) { }
}