using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models.Searches;
using HRMS.Database.Models;

namespace HRMS.Database.Repositories;

public class PayGradeRepository : BaseRepository<PayGrade, Core.Models.PayGrade, BaseSearch>, IPayGradeRepository
{
    public PayGradeRepository(Context context, IMapper mapper) : base(context, mapper) { }
}