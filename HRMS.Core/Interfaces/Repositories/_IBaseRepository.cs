using HRMS.Core.Models;
using HRMS.Core.Models.Searches;
using Task = System.Threading.Tasks.Task;

namespace HRMS.Core.Interfaces.Repositories;

public interface IBaseRepository<T, TSearch>
    where T : class
    where TSearch : BaseSearch
{
    Task<T> GetAsync(int id);
    Task<PagedResult<T>> GetAllAsync(TSearch? search = null);
    Task<T> InsertAsync(T model);
    Task InsertRangeAsync(IEnumerable<T> models);
    Task<T> UpdateAsync(T model);
    Task UpdateRangeAsync(IEnumerable<T> models);
    Task<bool> DeleteAsync(int id);
    Task DeleteRangeAsync(IEnumerable<T> models);
}