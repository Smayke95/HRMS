using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models.Searches;
using HRMS.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Database.Repositories;

public class EmployeePositionRepository : BaseRepository<EmployeePosition, Core.Models.EmployeePosition, EmployeePositionSearch>, IEmployeePositionRepository
{
    public EmployeePositionRepository(Context context, IMapper mapper) : base(context, mapper) { }

    public override async Task<Core.Models.EmployeePosition> GetAsync(int id)
    {
        var isNew = id == 0;

        if (!isNew)
        {
            var entity = await Context
                .EmployeePositions
                .Include(x => x.Employee)
                .Include(x => x.Position)
                .SingleOrDefaultAsync(x => x.Id == id);

            return Mapper.Map<Core.Models.EmployeePosition>(entity);
        }

        return new Core.Models.EmployeePosition();
    }

    protected override IQueryable<EmployeePosition> AddInclude(IQueryable<EmployeePosition> query, EmployeePositionSearch? search = null)
    {
        query = query.Include(x => x.Employee);
        query = query.Include(x => x.Position).ThenInclude(y => y!.Department);

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