using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models.Searches;
using HRMS.Database.Models;

namespace HRMS.Database.Repositories;

public class PayGradeRepository(Context context, IMapper mapper) : BaseRepository<PayGrade, Core.Models.PayGrade, BaseSearch>(context, mapper), IPayGradeRepository { }