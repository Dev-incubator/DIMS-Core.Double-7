using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    public abstract class ReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity>
        where TEntity : class
    {
        private readonly DbContext _context;
        protected ReadOnlyRepository(DimsCoreContext context)
        {
            _context = context;
        }

        public void Dispose() => _context?.Dispose();

        public IQueryable<TEntity> GetAll() => _context.Set<TEntity>().AsNoTracking();
    }
}