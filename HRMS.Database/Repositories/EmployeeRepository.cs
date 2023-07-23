using AutoMapper;
using HRMS.Core.Helpers;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models.Searches;
using Microsoft.EntityFrameworkCore;
using Employee = HRMS.Database.Models.Employee;

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
            .Include(x => x.Roles)
            .FirstOrDefaultAsync(x =>
                x.Email == email &&
                x.Password == EncryptionHelpers.Hash(password)
            );

        return Mapper.Map<Core.Models.Employee>(employee);
    }
}