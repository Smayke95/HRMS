using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models.Searches;
using HRMS.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Database.Repositories;

public class MessageRepository : BaseRepository<Message, Core.Models.Message, MessageSearch>, IMessageRepository
{
    public MessageRepository(Context context, IMapper mapper) : base(context, mapper) { }

    public override async Task<Core.Models.Message> GetAsync(int id)
    {
        var isNew = id == 0;

        if (!isNew)
        {
            var entity = await Context
                .Messages
                .Include(x => x.Employee)
                .SingleOrDefaultAsync(x => x.Id == id);

            return Mapper.Map<Core.Models.Message>(entity);
        }

        return new Core.Models.Message();
    }

    protected override IQueryable<Message> AddInclude(IQueryable<Message> query, MessageSearch? search = null)
    {
        if (search is null)
            return base.AddInclude(query, search);

        if (!string.IsNullOrWhiteSpace(search.Room))
            query = query.Where(x => x.Room.ToLower().Contains(search.Room.ToLower()));

        if (search.IncludeEmployee)
            query = query.Include(x => x.Employee);

        return query;
    }
}