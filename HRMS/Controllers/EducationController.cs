using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Searches;

namespace HRMS.Controllers;

public class EducationController : BaseController<Education, BaseSearch>
{
    public EducationController(IEducationRepository educationRepository) : base(educationRepository) { }
}