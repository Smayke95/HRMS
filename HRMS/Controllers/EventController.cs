using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Interfaces.Services;
using HRMS.Core.Models;
using HRMS.Core.Models.Enums;
using HRMS.Core.Models.Searches;
using HRMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers;

public class EventController(
    IMapper mapper,
    IEventRepository eventRepository,
    IEventService eventService)
    : BaseCrudController<Event, EventSearch, EventInsertUpdate, EventInsertUpdate>(mapper, eventRepository)
{
    private readonly IEventService EventService = eventService;

    /// <remarks>Insert new object</remarks>
    [HttpPost]
    public override async Task<Event> Insert([FromBody] EventInsertUpdate insert)
        => await EventService.InsertAsync(Mapper.Map<Event>(insert));

    /// <remarks>Get allowed actions by Id</remarks>
    [HttpGet("{id}/AllowedActions")]
    public async Task<IEnumerable<EventStatus>> AllowedActions(int id)
        => await EventService.AllowedActionsAsync(id);

    /// <remarks>Update object by Id</remarks>
    [HttpPut("{id}")]
    public override async Task<Event> Update(int id, [FromBody] EventInsertUpdate update)
        => await EventService.UpdateAsync(Mapper.Map<Event>(update));

    /// <remarks>Approve object by Id</remarks>
    [HttpPut("{id}/Approve")]
    public async Task<bool> Approve(int id)
        => await EventService.ApproveAsync(id);

    /// <remarks>Decline object by Id</remarks>
    [HttpPut("{id}/Decline")]
    public async Task<bool> Decline(int id)
        => await EventService.DeclineAsync(id);

    /// <remarks>Delete object by Id</remarks>
    [HttpDelete("{id}")]
    public override async Task<bool> Delete(int id)
        => await EventService.DeleteAsync(id);
}