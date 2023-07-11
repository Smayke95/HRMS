using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Searches;

namespace HRMS.Controllers;

public class PayGradeController : BaseController<PayGrade, BaseSearch>
{
    public PayGradeController(IPayGradeRepository payGradeRepository) : base(payGradeRepository) { }
}