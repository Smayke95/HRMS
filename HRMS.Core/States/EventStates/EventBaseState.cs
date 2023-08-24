using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Enums;

namespace HRMS.Core.States.EventStates;

public delegate EventBaseState? EventStateResolver(EventStatus eventStatus);

public class EventBaseState
{
    protected readonly IEventRepository EventRepository;

    public EventBaseState(IEventRepository eventRepository)
    {
        EventRepository = eventRepository;
    }

    public virtual List<EventStatus> AllowedActions { get; set; } = new();

    public virtual Task<Event> InsertAsync(Event calendarEvent)
        => throw new InvalidOperationException("Action not allowed");

    public virtual Task<Event> UpdateAsync(Event calendarEvent)
        => throw new InvalidOperationException("Action not allowed");

    public virtual Task<bool> ApproveAsync(Event calendarEvent)
        => throw new InvalidOperationException("Action not allowed");

    public virtual Task<bool> DeclineAsync(Event calendarEvent)
        => throw new InvalidOperationException("Action not allowed");

    public virtual Task<bool> DeleteAsync(Event calendarEvent)
        => throw new InvalidOperationException("Action not allowed");
}