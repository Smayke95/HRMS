using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models.Responses;
using HRMS.Core.Models.Searches;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Database.Repositories;

public abstract class BaseRepository<TDb, T, TSearch> : IBaseRepository<T, TSearch>
    where TDb : class
    where T : class, new()
    where TSearch : BaseSearch
{
    protected readonly Context Context;
    protected readonly IMapper Mapper;

    protected BaseRepository(
        Context context,
        IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
    }

    public virtual async Task<T> GetAsync(int id)
    {
        var isNew = id == 0;

        if (!isNew)
        {
            var entity = await Context
                .Set<TDb>()
                .FindAsync(id);

            return Mapper.Map<T>(entity);
        }

        return new T();
    }

    public virtual async Task<PagedResult<T>> GetAllAsync(TSearch? search = null)
    {
        var result = new PagedResult<T>();

        result.Page = search?.Page ?? 1;
        result.PageSize = search?.PageSize ?? 10;

        var query = Context
            .Set<TDb>()
            .AsQueryable();

        query = AddFilter(query, search);
        query = AddInclude(query, search);

        result.TotalCount = await query
            .AsNoTracking()
            .CountAsync();

        if (search is not null)
            query = query
                .Skip(search.PageSize * (search.Page - 1))
                .Take(search.PageSize);

        var list = await query
            .AsNoTracking()
            .ToListAsync();

        result.Result = Mapper.Map<List<T>>(list);
        return result;
    }

    protected virtual IQueryable<TDb> AddInclude(IQueryable<TDb> query, TSearch? search = null) => query;

    protected virtual IQueryable<TDb> AddFilter(IQueryable<TDb> query, TSearch? search = null) => query;

    public virtual async Task<T> InsertAsync(T model)
    {
        var entity = Mapper.Map<TDb>(model);

        var addedEntity = await Context
            .Set<TDb>()
            .AddAsync(entity);

        await Context.SaveChangesAsync();

        return Mapper.Map<T>(addedEntity.Entity);
    }

    public virtual async Task InsertRangeAsync(IEnumerable<T> models)
    {
        var entities = Mapper.Map<IEnumerable<TDb>>(models);

        await Context.Set<TDb>().AddRangeAsync(entities);
        await Context.SaveChangesAsync();
    }

    public virtual async Task<T> UpdateAsync(T model)
    {
        var entity = Mapper.Map<TDb>(model);

        var updatedEntity = Context
            .Set<TDb>()
            .Update(entity);

        await Context.SaveChangesAsync();

        return Mapper.Map<T>(updatedEntity.Entity);
    }

    public virtual async Task UpdateRangeAsync(IEnumerable<T> models)
    {
        var entities = Mapper.Map<IEnumerable<TDb>>(models);

        Context.Set<TDb>().UpdateRange(entities);
        await Context.SaveChangesAsync();
    }

    public virtual async Task<bool> DeleteAsync(int id)
    {
        var entity = await Context
            .Set<TDb>()
            .FindAsync(id);

        if (entity is null) return false;

        Context.Set<TDb>().Remove(entity);
        await Context.SaveChangesAsync();

        return true;
    }

    public virtual async Task DeleteRangeAsync(IEnumerable<T> models)
    {
        var entities = Mapper.Map<IEnumerable<TDb>>(models);

        Context.Set<TDb>().RemoveRange(entities);
        await Context.SaveChangesAsync();
    }
}