using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models.Searches;
using HRMS.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Database.Repositories;

public class PositionRepository : BaseRepository<Position, Core.Models.Position, PositionSearch>, IPositionRepository
{
    public PositionRepository(Context context, IMapper mapper) : base(context, mapper) { }

    public override async Task<Core.Models.Position> GetAsync(int id)
    {
        var isNew = id == 0;

        if (!isNew)
        {
            var entity = await Context
                .Positions
                .Include(x => x.Department)
                .Include(x => x.PayGrade)
                .Include(x => x.RequiredEducation)
                .SingleOrDefaultAsync(x => x.Id == id);

            return Mapper.Map<Core.Models.Position>(entity);
        }

        return new Core.Models.Position();
    }

    protected override IQueryable<Position> AddInclude(IQueryable<Position> query, PositionSearch? search = null)
    {
        if (search is null)
            return base.AddInclude(query, search);

        if (!string.IsNullOrWhiteSpace(search.Name))
            query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));

        if (search.IncludeDepartment)
            query = query.Include(x => x.Department);

        if (search.IncludePayGrade)
            query = query.Include(x => x.PayGrade);

        if (search.IncludeEducation)
            query = query.Include(x => x.RequiredEducation);

        return query;
    }
}