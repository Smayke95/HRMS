using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Enums;

namespace HRMS.Core.States.EmployeePositionStates;

public class EmployeePositionInitialState : EmployeePositionBaseState
{
    public EmployeePositionInitialState(IEmployeePositionRepository employeePositionRepository) : base(employeePositionRepository) { }

    public override List<EmploymentStatus> AllowedActions { get; set; } = new List<EmploymentStatus>() { EmploymentStatus.Inactive };

    public override async Task<EmployeePosition> InsertAsync(EmployeePosition employeePosition)
    {
        employeePosition.Status = EmploymentStatus.Inactive;
        return await EmployeePositionRepository.InsertAsync(employeePosition);
    }
}