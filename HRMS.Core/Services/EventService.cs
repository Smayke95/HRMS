using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Interfaces.Services;
using HRMS.Core.Models;
using HRMS.Core.Models.Enums;
using HRMS.Core.States.EventStates;

namespace HRMS.Core.Services;

public class EventService : IEventService
{
    private readonly EventStateResolver EventStateResolver;
    private readonly IEventRepository EventRepository;
    private readonly INotificationService NotificationService;

    public EventService(
        EventStateResolver eventStateResolver,
        IEventRepository eventRepository,
        INotificationService notificationService)
    {
        EventStateResolver = eventStateResolver;
        EventRepository = eventRepository;
        NotificationService = notificationService;
    }

    public async Task<Event> InsertAsync(Event calendarEvent)
    {
        var calendarEventState = EventStateResolver(EventStatus.Initial);
        var insertedEvent = await calendarEventState!.InsertAsync(calendarEvent);

        var notification = new Notification
        {
            Type = NotificationType.Info,
            Group = Role.Manager,
            Text = $"Novi događaj je dodan na odobrenje - {insertedEvent.Name}."
        };

        NotificationService.SendNotification(notification);

        return insertedEvent!;
    }

    public async Task<IEnumerable<EventStatus>> AllowedActionsAsync(int id)
    {
        var calendarEvent = await EventRepository.GetAsync(id);
        var calendarEventState = EventStateResolver(calendarEvent.Status);

        return calendarEventState!.AllowedActions;
    }

    public async Task<Event> UpdateAsync(Event calendarEvent)
    {
        var currentEvent = await EventRepository.GetAsync(calendarEvent.Id);
        var calendarEventState = EventStateResolver(currentEvent.Status);

        return await calendarEventState!.UpdateAsync(calendarEvent);
    }

    public async Task<bool> ApproveAsync(int id)
    {
        var calendarEvent = await EventRepository.GetAsync(id);
        var calendarEventState = EventStateResolver(calendarEvent.Status);

        return await calendarEventState!.ApproveAsync(calendarEvent);
    }

    public async Task<bool> DeclineAsync(int id)
    {
        var calendarEvent = await EventRepository.GetAsync(id);
        var calendarEventState = EventStateResolver(calendarEvent.Status);

        return await calendarEventState!.DeclineAsync(calendarEvent);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var calendarEvent = await EventRepository.GetAsync(id);
        var calendarEventState = EventStateResolver(calendarEvent.Status);

        return await calendarEventState!.DeleteAsync(calendarEvent);
    }
}