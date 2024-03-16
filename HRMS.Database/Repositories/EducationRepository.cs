using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models.Searches;
using HRMS.Database.Models;

namespace HRMS.Database.Repositories;

public class EducationRepository(Context context, IMapper mapper) : BaseRepository<Education, Core.Models.Education, BaseSearch>(context, mapper), IEducationRepository { }