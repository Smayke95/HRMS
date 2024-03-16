using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models.Searches;
using HRMS.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Database.Repositories;

public class DepartmentRepository(Context context, IMapper mapper) : BaseRepository<Department, Core.Models.Department, DepartmentSearch>(context, mapper), IDepartmentRepository
{
    public override async Task<Core.Models.Department> GetAsync(int id)
    {
        var isNew = id == 0;

        if (!isNew)
        {
            var entity = await Context
                .Departments
                .Include(x => x.ParentDepartment)
                .Include(x => x.Supervisor)
                .SingleOrDefaultAsync(x => x.Id == id);

            return Mapper.Map<Core.Models.Department>(entity);
        }

        return new Core.Models.Department();
    }

    protected override IQueryable<Department> AddInclude(IQueryable<Department> query, DepartmentSearch? search = null)
    {
        if (search is null)
            return base.AddInclude(query, search);

        if (!string.IsNullOrWhiteSpace(search.Name))
            query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));

        if (search.IncludeParentDepartment)
            query = query.Include(x => x.ParentDepartment);

        if (search.IncludeSupervisor)
            query = query.Include(x => x.Supervisor);

        return query;
    }
}