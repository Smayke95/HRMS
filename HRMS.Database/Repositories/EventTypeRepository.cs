using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models.Searches;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Database.Repositories;

public class EventTypeRepository(Context context, IMapper mapper) : BaseRepository<Models.EventType, Core.Models.EventType, EventTypeSearch>(context, mapper), IEventTypeRepository
{
    public override async Task<Core.Models.EventType> GetAsync(int id)
    {
        var isNew = id == 0;

        if (!isNew)
        {
            var entity = await Context
                .EventTypes
                .SingleOrDefaultAsync(x => x.Id == id);

            return Mapper.Map<Core.Models.EventType>(entity);
        }

        return new Core.Models.EventType();
    }

    protected override IQueryable<Models.EventType> AddInclude(IQueryable<Models.EventType> query, EventTypeSearch? search = null)
    {
        if (search is null)
            return base.AddInclude(query, search);

        if (!string.IsNullOrWhiteSpace(search.Name))
            query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));

        return query;
    }
}