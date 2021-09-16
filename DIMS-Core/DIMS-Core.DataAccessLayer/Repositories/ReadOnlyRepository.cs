using System.Linq;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    public class ReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity>
        where TEntity : class
    {
        private readonly DbContext _context;
        public void Dispose()
        {
            _context?.Dispose();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsNoTracking();
        }

        protected ReadOnlyRepository(DimsCoreContext context)
        {
            _context = context;
        }
    }
}