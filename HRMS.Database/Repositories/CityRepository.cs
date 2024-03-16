using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models.Searches;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Database.Repositories;

public class CityRepository(Context context, IMapper mapper) : BaseRepository<Models.City, Core.Models.City, CitySearch>(context, mapper), ICityRepository
{
    public override async Task<Core.Models.City> GetAsync(int id)
    {
        var isNew = id == 0;

        if (!isNew)
        {
            var entity = await Context
                .Cities
                .Include(x => x.Country)
                .SingleOrDefaultAsync(x => x.Id == id);

            return Mapper.Map<Core.Models.City>(entity);
        }

        return new Core.Models.City();
    }

    protected override IQueryable<Models.City> AddInclude(IQueryable<Models.City> query, CitySearch? search = null)
    {
        if (search is null)
            return base.AddInclude(query, search);

        if (!string.IsNullOrWhiteSpace(search.Name))
            query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));

        if (search.IncludeCountry)
            query = query.Include(x => x.Country);

        return query;
    }
}