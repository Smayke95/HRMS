using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Interfaces.Services;
using HRMS.Core.Models;
using HRMS.Core.Models.Enums;
using HRMS.Core.Models.Searches;
using HRMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers;

public class EmployeePositionController(
    IMapper mapper,
    IEmployeePositionRepository employeePositionRepository,
    IEmployeePositionService employeePositionService)
    : BaseCrudController<EmployeePosition, EmployeePositionSearch, EmployeePositionInsertUpdate, EmployeePositionInsertUpdate>(mapper, employeePositionRepository)
{
    private readonly IEmployeePositionService EmployeePositionService = employeePositionService;

    /// <remarks>Get allowed actions by Id</remarks>
    [HttpGet("{id}/AllowedActions")]
    public async Task<IEnumerable<EmploymentStatus>> AllowedActions(int id)
        => await EmployeePositionService.AllowedActionsAsync(id);

    /// <remarks>Insert new object</remarks>
    [HttpPost]
    public override async Task<EmployeePosition> Insert([FromBody] EmployeePositionInsertUpdate insert)
        => await EmployeePositionService.InsertAsync(Mapper.Map<EmployeePosition>(insert));

    /// <remarks>Update object by Id</remarks>
    [HttpPut("{id}")]
    public override async Task<EmployeePosition> Update(int id, [FromBody] EmployeePositionInsertUpdate update)
        => await EmployeePositionService.UpdateAsync(Mapper.Map<EmployeePosition>(update));

    /// <remarks>Activate object by Id</remarks>
    [HttpPut("{id}/Activate")]
    public async Task<bool> Activate(int id)
        => await EmployeePositionService.ActivateAsync(id);

    /// <remarks>Deactivate object by Id</remarks>
    [HttpPut("{id}/Deactivate")]
    public async Task<bool> Deactivate(int id)
        => await EmployeePositionService.DeactivateAsync(id);

    /// <remarks>Delete object by Id</remarks>
    [HttpDelete("{id}")]
    public override async Task<bool> Delete(int id)
        => await EmployeePositionService.DeleteAsync(id);
}