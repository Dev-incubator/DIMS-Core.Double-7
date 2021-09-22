using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.DataAccessLayer.Models
{
    public class ViewTestContext : DimsCoreContext
    {
        public ViewTestContext(DbContextOptions<DimsCoreContext> options) : base(options)
        {
            
        }
        public ViewTestContext(object dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            if (Database.IsInMemory())
            {
                modelBuilder.Entity<VUserProfile>()
                            .ToInMemoryQuery(() => new[]
                                                   {
                                                       new VUserProfile
                                                        {
                                                            Age = 0,
                                                            Education = "Test"
                                                        },
                                                    }.AsQueryable());
                modelBuilder.Entity<VUserTrack>()
                            .ToInMemoryQuery(() => new[]
                                                   {
                                                       new VUserTrack
                                                       {
                                                           
                                                       },
                                                   }.AsQueryable());
                modelBuilder.Entity<VTask>()
                            .ToInMemoryQuery(() => new[]
                                                   {
                                                       new VTask
                                                       {
                                                           
                                                       },
                                                   }.AsQueryable());
            }
        }
    }
}