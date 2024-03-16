using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Enums;

namespace HRMS.Core.States.EventStates;

public class EventInitialState(IEventRepository employeePositionRepository) : EventBaseState(employeePositionRepository)
{
    public override List<EventStatus> AllowedActions { get; set; } = new List<EventStatus>() { EventStatus.Approved, EventStatus.Declined };

    public override async Task<Event> UpdateAsync(Event calendarEvent)
    => await EventRepository.UpdateAsync(calendarEvent);

    public override async Task<Event> InsertAsync(Event calendarEvent)
    {
        calendarEvent.Status = EventStatus.Initial;
        return await EventRepository.InsertAsync(calendarEvent);
    }

    public override async Task<bool> ApproveAsync(Event calendarEvent)
    {
        calendarEvent.Status = EventStatus.Approved;
        await EventRepository.UpdateAsync(calendarEvent);

        return true;
    }

    public override async Task<bool> DeclineAsync(Event calendarEvent)
    {
        calendarEvent.Status = EventStatus.Declined;
        await EventRepository.UpdateAsync(calendarEvent);

        return true;
    }
}