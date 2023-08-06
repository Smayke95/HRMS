using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Searches;
using HRMS.Models;

namespace HRMS.Controllers;

public class EventController : BaseCrudController<Event, BaseSearch, EventInsert, EventUpdate>
{
    public EventController(IMapper mapper, IEventRepository eventRepository) : base(mapper, eventRepository) { }
}