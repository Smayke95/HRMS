using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Enums;

namespace HRMS.Core.States.EmployeePositionStates;

public class EmployeePositionInactiveState : EmployeePositionBaseState
{
    public EmployeePositionInactiveState(IEmployeePositionRepository employeePositionRepository) : base(employeePositionRepository) { }

    public override List<EmploymentStatus> AllowedActions { get; set; } = new List<EmploymentStatus>() { EmploymentStatus.Active, EmploymentStatus.Deleted };

    public override async Task<EmployeePosition> UpdateAsync(EmployeePosition employeePosition)
        => await EmployeePositionRepository.UpdateAsync(employeePosition);

    public override async Task<bool> ActivateAsync(EmployeePosition employeePosition)
    {
        employeePosition.Status = EmploymentStatus.Active;
        await EmployeePositionRepository.UpdateAsync(employeePosition);

        return true;
    }

    public override async Task<bool> DeleteAsync(EmployeePosition employeePosition)
    {
        employeePosition.Status = EmploymentStatus.Deleted;
        await EmployeePositionRepository.UpdateAsync(employeePosition);

        return true;
    }
}