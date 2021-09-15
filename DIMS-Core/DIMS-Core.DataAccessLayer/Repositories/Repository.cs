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
    ///     TODO: Task #1
    ///     Implement all methods
    ///     Generic Repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly DbContext _context;
        protected readonly DbSet<TEntity> Set;

        protected DatabaseFacade GetDb()
        {
            return _context.Database;
        }
        protected Repository(DbContext context)
        {
            _context = context;
            Set = context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return Set.AsNoTracking();
        }

        public async Task<TEntity> GetById(int id)
        {
            RepositoryException.IsIdValid(id);

            TEntity objectFromDB = await Set.FindAsync(id);

            RepositoryException.IsEntityExists(objectFromDB, nameof(objectFromDB));

            return objectFromDB;
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

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}