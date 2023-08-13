using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models.Searches;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Database.Repositories;

public class EventRepository : BaseRepository<Models.Event, Core.Models.Event, EventSearch>, IEventRepository
{
    public EventRepository(Context context, IMapper mapper) : base(context, mapper) { }

    public override async Task<Core.Models.Event> GetAsync(int id)
    {
        var isNew = id == 0;

        if (!isNew)
        {
            var entity = await Context
                .Events
                .Include(x => x.EventType)
                .Include(x => x.Employee)
                .SingleOrDefaultAsync(x => x.Id == id);

            return Mapper.Map<Core.Models.Event>(entity);
        }

        return new Core.Models.Event();
    }

    protected override IQueryable<Models.Event> AddInclude(IQueryable<Models.Event> query, EventSearch? search = null)
    {
        if (search is null)
            return base.AddInclude(query, search);

        if (!string.IsNullOrWhiteSpace(search.Name))
            query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));

        if (search.EmployeeId > 0)
            query = query.Where(x => x.Employee!.Id == search.EmployeeId);

        if (search.IncludeEventType)
            query = query.Include(x => x.EventType);

        if (search.IncludeEmployee)
            query = query.Include(x => x.Employee);

        return query;
    }
}