using EcommerceCenima.Models;
using System.Linq.Expressions;

namespace EcommerceCenima.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class,IEntityBase,new()  
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProprites);
		Task AddAsync(T entity);
        Task<T> DetailsAsync(int Id);
        Task EditAsync(int id, T entity);
        Task DeleteAsync(int id);
    }
}
