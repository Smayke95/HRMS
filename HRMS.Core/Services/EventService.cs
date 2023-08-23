using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Interfaces.Services;
using HRMS.Core.Models;
using HRMS.Core.Models.Enums;

namespace HRMS.Core.Services;

public class EventService : IEventService
{
    private readonly IEventRepository EventRepository;
    private readonly INotificationService NotificationService;

    public EventService(
        IEventRepository eventRepository,
        INotificationService notificationService)
    {
        EventRepository = eventRepository;
        NotificationService = notificationService;
    }

    public async Task<Event> InsertAsync(Event calendarEvent)
    {
        var insertedEvent = await EventRepository.InsertAsync(calendarEvent);

        var notification = new Notification
        {
            Type = NotificationType.Info,
            Group = Role.Manager,
            Text = $"Novi događaj je dodan na odobrenje - {insertedEvent.Name}."
        };

        NotificationService.SendNotification(notification);

        return insertedEvent;
    }
}