using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Searches;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers;

public abstract class BaseCrudController<T, TSearch, TInsert, TUpdate> : BaseController<T, TSearch>
    where T : Base
    where TSearch : BaseSearch
    where TInsert : class
    where TUpdate : class
{
    protected readonly IMapper Mapper;
    private readonly IBaseRepository<T, TSearch> BaseRepository;

    protected BaseCrudController(
        IMapper mapper,
        IBaseRepository<T, TSearch> baseRepository
        ) : base(baseRepository)
    {
        Mapper = mapper;
        BaseRepository = baseRepository;
    }

    /// <remarks>Insert new object</remarks>
    [HttpPost]
    public async Task<T> Insert([FromBody] TInsert insert)
         => await BaseRepository.InsertAsync(Mapper.Map<T>(insert));

    /// <remarks>Update object by Id</remarks>
    [HttpPut("{id}")]
    public async Task<T> Update(int id, [FromBody] TUpdate update)
        => await BaseRepository.UpdateAsync(Mapper.Map<T>(update, opt => opt.AfterMap((src, dest) => dest.Id = id)));

    /// <remarks>Delete object by Id</remarks>
    [HttpDelete("{id}")]
    public async Task<bool> Delete(int id)
        => await BaseRepository.DeleteAsync(id);
}