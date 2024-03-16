using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Searches;
using HRMS.Models;

namespace HRMS.Controllers;

public class EventTypeController(IMapper mapper, IEventTypeRepository eventTypeRepository) : BaseCrudController<EventType, EventTypeSearch, EventTypeInsertUpdate, EventTypeInsertUpdate>(mapper, eventTypeRepository) { }