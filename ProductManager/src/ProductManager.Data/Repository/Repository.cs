using Microsoft.EntityFrameworkCore;
using ProductManager.Data.Context;
using ProductManager.Domain.Interfaces.Respositories;
using ProductManager.Domain.Models.Entities;
using System.Linq.Expressions;

namespace ProductManager.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly ManagerDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(ManagerDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }
        public async Task<List<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }
        public virtual async Task Add(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }
        public virtual async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }
        public virtual async Task Remove(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id});
            await SaveChanges();
        }
        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public async Task<IEnumerable<TEntity>> GetPaged(int pageNumber, int pageSize)
        {
            return await DbSet
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
