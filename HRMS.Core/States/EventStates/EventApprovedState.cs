using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Enums;

namespace HRMS.Core.States.EventStates;

public class EventApprovedState : EventBaseState
{
    public EventApprovedState(IEventRepository eventRepository) : base(eventRepository) { }

    public override List<EventStatus> AllowedActions { get; set; } = new() { EventStatus.Declined, EventStatus.Deleted };

    public override async Task<Event> UpdateAsync(Event calendarEvent)
        => await EventRepository.UpdateAsync(calendarEvent);

    public override async Task<bool> DeclineAsync(Event calendarEvent)
    {
        calendarEvent.Status = EventStatus.Declined;
        await EventRepository.UpdateAsync(calendarEvent);

        return true;
    }

    public override async Task<bool> DeleteAsync(Event calendarEvent)
    {
        calendarEvent.Status = EventStatus.Deleted;
        await EventRepository.UpdateAsync(calendarEvent);

        return true;
    }
}