using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models.Searches;
using HRMS.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Database.Repositories;

public class DepartmentRepository : BaseRepository<Department, Core.Models.Department, DepartmentSearch>, IDepartmentRepository
{
    public DepartmentRepository(Context context, IMapper mapper) : base(context, mapper) { }

    protected override IQueryable<Department> AddInclude(IQueryable<Department> query, DepartmentSearch? search = null)
    {
        return query.Include(x => x.Supervisor);
    }
}