using System;
using System.Linq;
using System.Threading.Tasks;
using DIMS_Core.Common.Exceptions;
using DIMS_Core.DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    /// <summary>
    /// Base Repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly DbContext _context;
        protected readonly DbSet<TEntity> Set;

        protected Repository(DbContext context)
        {
            _context = context;
            Set = context.Set<TEntity>();
        }

        protected DatabaseFacade GetDb()
        {
            return _context.Database;
        }

        public IQueryable<TEntity> GetAll()
        {
            return Set.AsNoTracking();
        }

        public async Task<TEntity> GetById(int id)
        {
            var range = new Range(1, Set.Count());
            RepositoryException.IsIdValid(id, range);
            
            var foundEntity = await Set.FindAsync(id);

            RepositoryException.IsEntityExists(foundEntity, foundEntity.GetType().FullName);

            return foundEntity;
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            var addedEntity =  await Set.AddAsync(entity);
            return addedEntity.Entity;
        }

        public TEntity Update(TEntity entity)
        {
            var updatedEntity = Set.Update(entity);
            return updatedEntity.Entity;
        }

        public async Task Delete(int id)
        {
            var deletedEntity = await Set.FindAsync(id);
            Set.Remove(deletedEntity);
        }

        public Task Save() => _context.SaveChangesAsync();

        /// <summary>
        ///     In most cases this method is not important because our context will be disposed by IoC automatically.
        ///     But if you don't know where will use your service better to specify this method (example, class library).
        /// </summary>
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}