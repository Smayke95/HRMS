using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Enums;

namespace HRMS.Core.States.EmployeePositionStates;

public delegate EmployeePositionBaseState? EmployeePositionStateResolver(EmploymentStatus employmentStatus);

public class EmployeePositionBaseState(IEmployeePositionRepository employeePositionRepository)
{
    protected readonly IEmployeePositionRepository EmployeePositionRepository = employeePositionRepository;

    public virtual List<EmploymentStatus> AllowedActions { get; set; } = new();

    public virtual Task<EmployeePosition> InsertAsync(EmployeePosition employeePosition)
        => throw new InvalidOperationException("Action not allowed");

    public virtual Task<EmployeePosition> UpdateAsync(EmployeePosition employeePosition)
        => throw new InvalidOperationException("Action not allowed");

    public virtual Task<bool> ActivateAsync(EmployeePosition employeePosition)
        => throw new InvalidOperationException("Action not allowed");

    public virtual Task<bool> DeactivateAsync(EmployeePosition employeePosition)
        => throw new InvalidOperationException("Action not allowed");

    public virtual Task<bool> DeleteAsync(EmployeePosition employeePosition)
        => throw new InvalidOperationException("Action not allowed");
}