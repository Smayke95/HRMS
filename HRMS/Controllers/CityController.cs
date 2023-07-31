using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Searches;
using HRMS.Models;

namespace HRMS.Controllers;

public class CityController : BaseCrudController<City, CitySearch, CityInsert, CityUpdate>
{
    public CityController(IMapper mapper, ICityRepository cityRepository) : base(mapper, cityRepository) { }
}