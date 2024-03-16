using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Searches;

namespace HRMS.Controllers;

public class EducationController(IEducationRepository educationRepository) : BaseController<Education, BaseSearch>(educationRepository) { }