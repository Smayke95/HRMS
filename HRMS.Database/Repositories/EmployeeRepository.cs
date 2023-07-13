using AutoMapper;
using HRMS.Core.Helpers;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Searches;
using HRMS.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Database.Repositories;

public class EmployeeRepository : BaseRepository<Employee, Core.Models.Employee, EmployeeSearch>, IEmployeeRepository
{
    public EmployeeRepository(Context context, IMapper mapper) : base(context, mapper) { }

    protected override IQueryable<Employee> AddInclude(IQueryable<Employee> query, EmployeeSearch? search = null)
    {
        if (search is null)
            return base.AddInclude(query, search);

        if (!string.IsNullOrWhiteSpace(search.Name))
            query = query.Where(x =>
                x.FirstName.ToLower().Contains(search.Name.ToLower()) ||
                x.LastName.ToLower().Contains(search.Name.ToLower()) ||
                x.RegistrationNumber.ToLower().Contains(search.Name.ToLower()) ||
                x.WorkerCode.ToLower().Contains(search.Name.ToLower()) ||
                x.Email.ToLower().Contains(search.Name.ToLower())
            );

        if (search.IncludeCity)
            query = query.Include(x => x.City);

        if (search.IncludeCountry)
            query = query.Include(x => x.Citizenship);

        if (search.IncludeEducation)
            query = query.Include(x => x.Education);

        return query;
    }

    public async Task<Core.Models.Employee> GetByEmailAndPasswordAsync(string email, string password)
    {
        var employee = await Context
            .Employees
            .FirstOrDefaultAsync(x =>
                x.Email == email &&
                x.Password == EncryptionHelpers.Hash(password)
            );

        return Mapper.Map<Core.Models.Employee>(employee);
    }

    public async Task<PagedResult<Core.Models.Employee>> SearchAsync(EmployeeSearch search)
    {
        var result = new PagedResult<Core.Models.Employee>();

        if (search is null)
            return result;

        result.Page = search?.Page ?? 1;
        result.PageSize = search?.PageSize ?? 10;

        var employees = await Context
            .Employees
            .Where(x =>
                EF.Functions.Contains(x.FirstName, $"\"{search!.Name}\"")
            )
            .ToListAsync();

        result.Result = Mapper.Map<List<Core.Models.Employee>>(employees);
        return result;
    }
}