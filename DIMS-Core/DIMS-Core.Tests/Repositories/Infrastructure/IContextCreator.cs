using DIMS_Core.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.Tests.Repositories.Infrastructure
{
    public interface IContextCreator<T> where T : DbContext
    {
        T CreateContext(DbContextOptions<T> options);
    }
}