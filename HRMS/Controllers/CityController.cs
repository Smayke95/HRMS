using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Searches;
using HRMS.Models;

namespace HRMS.Controllers;

public class CityController(IMapper mapper, ICityRepository cityRepository) : BaseCrudController<City, CitySearch, CityInsertUpdate, CityInsertUpdate>(mapper, cityRepository) { }