using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Enums;

namespace HRMS.Core.States.EventStates;

public class EventDeclinedState : EventBaseState
{
    public EventDeclinedState(IEventRepository eventRepository) : base(eventRepository) { }

    public override List<EventStatus> AllowedActions { get; set; } = new List<EventStatus>() { EventStatus.Approved, EventStatus.Deleted };

    public override async Task<Event> UpdateAsync(Event calendarEvent)
        => await EventRepository.UpdateAsync(calendarEvent);

    public override async Task<bool> ApproveAsync(Event calendarEvent)
    {
        calendarEvent.Status = EventStatus.Approved;
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