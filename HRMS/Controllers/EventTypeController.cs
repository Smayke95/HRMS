using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Searches;
using HRMS.Models;

namespace HRMS.Controllers;

public class EventTypeController : BaseCrudController<EventType, EventTypeSearch, EventTypeInsert, EventTypeUpdate>
{
    public EventTypeController(IMapper mapper, IEventTypeRepository eventTypeRepository) : base(mapper, eventTypeRepository) { }
}