using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Enums;

namespace HRMS.Core.States.EmployeePositionStates;

public class EmployeePositionActiveState : EmployeePositionBaseState
{
    public EmployeePositionActiveState(IEmployeePositionRepository employeePositionRepository) : base(employeePositionRepository) { }

    public override List<EmploymentStatus> AllowedActions { get; set; } = new() { EmploymentStatus.Inactive };

    public override async Task<bool> DeactivateAsync(EmployeePosition employeePosition)
    {
        employeePosition.Status = EmploymentStatus.Inactive;
        await EmployeePositionRepository.UpdateAsync(employeePosition);

        return true;
    }
}