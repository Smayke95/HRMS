using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Interfaces.Services;
using HRMS.Core.Models;
using HRMS.Core.Models.Enums;
using HRMS.Core.States.EmployeePositionStates;

namespace HRMS.Core.Services;

public class EmployeePositionService(
    EmployeePositionStateResolver employeePositionStateResolver,
    IEmployeePositionRepository employeePositionRepository)
    : IEmployeePositionService
{
    private readonly EmployeePositionStateResolver EmployeePositionStateResolver = employeePositionStateResolver;
    private readonly IEmployeePositionRepository EmployeePositionRepository = employeePositionRepository;

    public async Task<IEnumerable<EmploymentStatus>> AllowedActionsAsync(int id)
    {
        var employeePosition = await EmployeePositionRepository.GetAsync(id);
        var employeePositionState = EmployeePositionStateResolver(employeePosition.Status);

        return employeePositionState!.AllowedActions;
    }

    public async Task<EmployeePosition> InsertAsync(EmployeePosition employeePosition)
    {
        var employeePositionState = EmployeePositionStateResolver(EmploymentStatus.Initial);

        return await employeePositionState!.InsertAsync(employeePosition);
    }

    public async Task<EmployeePosition> UpdateAsync(EmployeePosition employeePosition)
    {
        var currentEmployeePosition = await EmployeePositionRepository.GetAsync(employeePosition.Id);
        var employeePositionState = EmployeePositionStateResolver(currentEmployeePosition.Status);

        return await employeePositionState!.UpdateAsync(employeePosition);
    }

    public async Task<bool> ActivateAsync(int id)
    {
        var employeePosition = await EmployeePositionRepository.GetAsync(id);
        var employeePositionState = EmployeePositionStateResolver(employeePosition.Status);

        return await employeePositionState!.ActivateAsync(employeePosition);
    }

    public async Task<bool> DeactivateAsync(int id)
    {
        var employeePosition = await EmployeePositionRepository.GetAsync(id);
        var employeePositionState = EmployeePositionStateResolver(employeePosition.Status);

        return await employeePositionState!.DeactivateAsync(employeePosition);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var employeePosition = await EmployeePositionRepository.GetAsync(id);
        var employeePositionState = EmployeePositionStateResolver(employeePosition.Status);

        return await employeePositionState!.DeleteAsync(employeePosition);
    }
}