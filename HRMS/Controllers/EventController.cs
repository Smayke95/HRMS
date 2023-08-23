using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Interfaces.Services;
using HRMS.Core.Models;
using HRMS.Core.Models.Searches;
using HRMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers;

public class EventController : BaseCrudController<Event, EventSearch, EventInsertUpdate, EventInsertUpdate>
{
    private readonly IEventService EventService;

    public EventController(
        IMapper mapper,
        IEventRepository eventRepository,
        IEventService eventService)
        : base(mapper, eventRepository)
    {
        EventService = eventService;
    }

    /// <remarks>Insert new object</remarks>
    [HttpPost]
    public override async Task<Event> Insert([FromBody] EventInsertUpdate insert)
        => await EventService.InsertAsync(Mapper.Map<Event>(insert));
}