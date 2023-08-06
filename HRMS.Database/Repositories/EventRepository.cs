using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models.Searches;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Database.Repositories;

public class EventRepository : BaseRepository<Models.Event, Core.Models.Event, BaseSearch>, IEventRepository
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
}