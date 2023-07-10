using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models.Searches;
using HRMS.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Database.Repositories;

public class EmployeePositionRepository : BaseRepository<EmployeePosition, Core.Models.EmployeePosition, EmployeePositionSearch>, IEmployeePositionRepository
{
    public EmployeePositionRepository(Context context, IMapper mapper) : base(context, mapper) { }

    protected override IQueryable<EmployeePosition> AddInclude(IQueryable<EmployeePosition> query, EmployeePositionSearch? search = null)
    {
        query = query.Include(x => x.Employee);
        query = query.Include(x => x.Position);

        if (search is null)
            return base.AddInclude(query, search);

        if (!string.IsNullOrWhiteSpace(search.Name))
            query = query.Where(x =>
                x.Employee!.FirstName.ToLower().Contains(search.Name.ToLower()) ||
                x.Employee!.LastName.ToLower().Contains(search.Name.ToLower()) ||
                x.Position!.Name.ToLower().Contains(search.Name.ToLower())
            );

        return query;
    }
}