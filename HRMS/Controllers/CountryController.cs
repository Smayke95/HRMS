using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Searches;
using HRMS.Models;

namespace HRMS.Controllers;

public class CountryController(IMapper mapper, ICountryRepository countryRepository) : BaseCrudController<Country, CountrySearch, CountryInsertUpdate, CountryInsertUpdate>(mapper, countryRepository) { }