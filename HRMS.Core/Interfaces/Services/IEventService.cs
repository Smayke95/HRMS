using HRMS.Core.Models;
using HRMS.Core.Models.Enums;

namespace HRMS.Core.Interfaces.Services;

public interface IEventService
{
    Task<IEnumerable<EventStatus>> AllowedActionsAsync(int id);
    Task<Event> InsertAsync(Event employeePosition);
    Task<Event> UpdateAsync(Event employeePosition);
    Task<bool> ApproveAsync(int id);
    Task<bool> DeclineAsync(int id);
    Task<bool> DeleteAsync(int id);
}