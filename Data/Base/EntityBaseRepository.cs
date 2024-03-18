
using EcommerceCenima.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace EcommerceCenima.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext context;

        public EntityBaseRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await context.Set<T>().FirstOrDefaultAsync(a => a.Id == id);
            EntityEntry entityEntry = context.Entry(entity);
            entityEntry.State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }

        public async Task<T> DetailsAsync(int Id)
        {
            var result = await context.Set<T>().FirstOrDefaultAsync(a => a.Id == Id);
            return result;
        }

        public async Task EditAsync(int id, T entity)
        {
            EntityEntry entityEntry = context.Entry(entity);
            entityEntry.State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await context.Set<T>().ToListAsync();
            return result;
        }
        public async Task<IEnumerable<T>>  GetAllAsync(params Expression<Func<T, object>>[] includeProprites)
        {
            IQueryable<T> query = context.Set<T>();
            query = includeProprites.Aggregate(query, (current, includeProprites) => current.Include(includeProprites));
            return await query.ToListAsync();

		}

	}
}
