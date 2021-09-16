using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DIMS_Core.DataAccessLayer.Extensions
{
    public static class MiddlewareServiceExtensions
    {
        public static IServiceCollection AddDatabaseDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<Repository<Direction>, DirectionRepository>();
            services.AddScoped<Repository<UserProfile>, UserProfileRepository>();
            services.AddScoped<Repository<Task>, TaskRepository>();
            services.AddScoped<ReadOnlyRepository<VUserProfile>, VUserProfileRepository>();
            services.AddScoped<ReadOnlyRepository<VTask>, VTaskRepository>();
            services.AddScoped<ReadOnlyRepository<VUserTrack>, VUserTrackRepository>();

            return services;
        }

        public static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DimsCoreContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DIMSDatabase"));
            });

            return services;
        }
    }
}