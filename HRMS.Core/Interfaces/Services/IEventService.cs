using HRMS.Core.Models;

namespace HRMS.Core.Interfaces.Services;

public interface IEventService
{
    Task<Event> InsertAsync(Event calendarEvent);
}