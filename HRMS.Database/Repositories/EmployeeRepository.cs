using AutoMapper;
using HRMS.Core.Helpers;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models.Searches;
using Microsoft.EntityFrameworkCore;
using Employee = HRMS.Database.Models.Employee;

namespace HRMS.Database.Repositories;

public class EmployeeRepository(Context context, IMapper mapper) : BaseRepository<Employee, Core.Models.Employee, EmployeeSearch>(context, mapper), IEmployeeRepository
{
    public override async Task<Core.Models.Employee> GetAsync(int id)
    {
        var isNew = id == 0;

        if (!isNew)
        {
            var entity = await Context
                .Employees
                .Include(x => x.BirthPlace)
                .Include(x => x.City)
                .Include(x => x.Citizenship)
                .Include(x => x.Education)
                .SingleOrDefaultAsync(x => x.Id == id);

            return Mapper.Map<Core.Models.Employee>(entity);
        }

        return new Core.Models.Employee();
    }

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